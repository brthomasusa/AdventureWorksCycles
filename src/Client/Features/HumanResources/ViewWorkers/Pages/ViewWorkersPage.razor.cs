using AWC.Client.Features.HumanResources.ViewWorkerDetails.Pages;
using AWC.Client.Utilities;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Shared;
using Grpc.Net.Client;
using MapsterMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace AWC.Client.Features.HumanResources.ViewWorkers.Pages
{
    public partial class ViewWorkersPage : ComponentBase
    {
        private const int VIEW_EMPLOYEE = 1;
        private const int EDIT_EMPLOYEE = 2;
        private const int DELETE_EMPLOYEE = 3;

        private bool isLoading;
        private int count;
        private int selectedEmployeeID;
        private IEnumerable<EmployeeListItem>? employeeListItems;
        private readonly IEnumerable<int> pageSizeOptions = new List<int>() { 5, 10, 15, 20 };
        private RadzenDataGrid<EmployeeListItem>? employeeListItemGrid;

        [Inject] protected NotificationService? NotificationService { get; set; }
        [Inject] protected DialogService? DialogService { get; set; }
        [Inject] protected ContextMenuService? ContextMenuService { get; set; }
        [Inject] private GrpcChannel? GrpcChannel { get; set; }
        [Inject] private IMapper? Mapper { get; set; }

        protected async Task LoadEmployeeListData(LoadDataArgs args)
        {
            try
            {
                string searchField = string.Empty;
                string searchCriteria = string.Empty;

                if (args.Filters is not null)
                {
                    List<FilterDescriptor> descriptors = args.Filters.ToList();
                    FilterDescriptor? filterDescriptor
                        = descriptors.Find(x => !string.IsNullOrEmpty(x.Property) && !string.IsNullOrEmpty(x.FilterValue.ToString()));

                    if (filterDescriptor is not null)
                    {
                        searchField = filterDescriptor.Property;
                        searchCriteria = filterDescriptor.FilterValue.ToString()!;
                    }
                }

                StringSearchCriteria criteria = new
                (
                    searchField,
                    searchCriteria,
                    !string.IsNullOrEmpty(args.OrderBy) ? args.OrderBy : string.Empty,
                    0,
                    0,
                    args.Skip ?? default,
                    args.Top ?? default
                );

                isLoading = true;

                await GetEmployeeListItems(criteria);

                isLoading = false;

                await InvokeAsync(StateHasChanged);

            }
            catch (Exception ex)
            {
                NotificationService!.Notify(
                    new NotificationMessage
                    {
                        Severity = NotificationSeverity.Error,
                        Style = "position: relative; left: -500px; top: 490px; width: 100%",
                        Detail = Helpers.GetExceptionMessage(ex),
                        Duration = 2500
                    }
                );
            }
        }

        private async Task GetEmployeeListItems(StringSearchCriteria criteria)
        {
            var client = new EmployeeContract.EmployeeContractClient(GrpcChannel);
            grpc_EmployeeListItems grpcResponse =
                await client.GetEmployeesSearchByNameAsync(Mapper!.Map<grpc_StringSearchCriteria>(criteria));

            List<EmployeeListItem> employees = new();
            grpcResponse.GrpcEmployees.ToList()
                                      .ForEach(grpcDept => employees.Add(Mapper.Map<EmployeeListItem>(grpcDept)));

            employeeListItems = employees;
            count = grpcResponse.GrpcMetaData["TotalCount"];
        }

        private void ShowContextMenu(MouseEventArgs args, dynamic data)
        {
            selectedEmployeeID = data.BusinessEntityID;

            ContextMenuService!.Open(args,
                new List<ContextMenuItem> {
                new ContextMenuItem(){ Text = "View", Value = 1, Icon = "visibility" },
                new ContextMenuItem(){ Text = "Edit", Value = 2, Icon = "edit" },
                new ContextMenuItem(){ Text = "Delete", Value = 3, Icon = "delete_forever" },
             }, OnMenuItemClick);
        }

        private async void OnMenuItemClick(MenuItemEventArgs args)
        {
            switch (args.Value)
            {
                case VIEW_EMPLOYEE:
                    await ShowViewEmployeeDialog();
                    break;
                case EDIT_EMPLOYEE:
                    Console.WriteLine($"Menu item edit clicked with employee id {selectedEmployeeID}");
                    break;
                case DELETE_EMPLOYEE:
                    Console.WriteLine($"Menu item delete clicked with employee id {selectedEmployeeID}");
                    break;
                default:
                    NotificationService!.Notify
                    (
                        new NotificationMessage()
                        {
                            Severity = NotificationSeverity.Error,
                            Summary = $"Error",
                            Detail = $"Invalid menu selection."
                        }
                    );
                    break;
            }

            ContextMenuService!.Close();
        }

        protected async Task ShowViewEmployeeDialog()
        {
            var dialogResult =
                await DialogService!.OpenAsync<ViewEmployeeDialog>
                    (
                        "Viewing employee details",
                        new Dictionary<string, object>() { { "BusinessEntityID", selectedEmployeeID } },
                        new DialogOptions() { Width = "1000px", Height = "600px", Resizable = true, Draggable = true }
                    );

            await employeeListItemGrid!.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }
    }
}
