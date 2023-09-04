using AWC.Client.Features.HumanResources.CreateWorker.Pages;
using AWC.Client.Features.HumanResources.ViewWorkerDetails.Pages;
using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Utilities;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace AWC.Client.Features.HumanResources.ViewWorkers.Pages
{
    public partial class ViewWorkersPage : ComponentBase
    {
        private const int VIEW_EMPLOYEE = 1;
        private const int CREATE_EMPLOYEE = 2;
        private const int EDIT_EMPLOYEE = 3;
        private const int DELETE_EMPLOYEE = 4;

        private bool isLoading;
        private int count;
        private int selectedEmployeeID;
        private IEnumerable<EmployeeListItem>? employeeListItems;
        private readonly IEnumerable<int> pageSizeOptions = new List<int>() { 5, 10, 15, 20 };
        private RadzenDataGrid<EmployeeListItem>? employeeListItemGrid;

        [Inject] protected NotificationService? NotificationService { get; set; }
        [Inject] protected DialogService? DialogService { get; set; }
        [Inject] protected ContextMenuService? ContextMenuService { get; set; }
        [Inject] private IEmployeeRepositoryService? EmployeeRepository { get; set; }

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
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    Helpers.GetExceptionMessage(ex)
                );
            }
        }

        private async Task GetEmployeeListItems(StringSearchCriteria criteria)
        {
            Result<PagedList<EmployeeListItem>> result = await EmployeeRepository!.GetEmployeeListItems(criteria);

            if (result.IsFailure)
            {
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    result.Error.Message
                );
            }
            else
            {
                employeeListItems = result.Value.Items;
                count = result.Value.MetaData!.TotalCount;
            }
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
                    // await ShowCreateWorkerDialog();
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
                            Summary = "Error",
                            Detail = "Invalid menu selection."
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
                        new DialogOptions() { Width = "1100px", Height = "700px", Resizable = true, Draggable = true }
                    );

            await employeeListItemGrid!.Reload();

            await InvokeAsync(() => StateHasChanged());
        }

        protected async Task ShowCreateWorkerDialog()
        {
            var dialogResult = await DialogService!.OpenAsync<CreateWorkerDialog>(
                "Create Worker",
                null,
                new DialogOptions() { Width = "1200px", Height = "700px", Resizable = true, Draggable = true }
            );

            await employeeListItemGrid!.Reload();

            await InvokeAsync(() => StateHasChanged());
        }
    }
}
