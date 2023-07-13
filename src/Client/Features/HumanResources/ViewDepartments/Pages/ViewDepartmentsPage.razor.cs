using AWC.Client.Features.HumanResources.ViewDepartments.Store;
using AWC.Client.Utilities;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;


namespace AWC.Client.Features.HumanResources.ViewDepartments.Pages
{
    public partial class ViewDepartmentsPage
    {
        protected NotificationService? NotificationService { get; set; }
        [Inject] private IState<ViewDepartmentsState>? ViewDepartmentsState { get; set; }
        [Inject] private IDispatcher? Dispatcher { get; set; }
        private bool Loading => ViewDepartmentsState!.Value.Loading;
        protected RadzenDataGrid<DepartmentDetails>? departmentGrid;

        protected override void OnInitialized()
        {
            if (!ViewDepartmentsState!.Value.Initialized)
            {
                Dispatcher!.Dispatch(new GetDepartmentsAction(ViewDepartmentsState!.Value.SearchCriteria!));
            }

            base.OnInitialized();
        }

        protected async Task GridLoadData(LoadDataArgs args)
        {
            try
            {
                int currentPage = departmentGrid!.CurrentPage;
                int totalPages = ViewDepartmentsState!.Value.MetaData!.TotalPages;

                Console.WriteLine($"CurrentPage before: {currentPage}, TotalPages: {totalPages}");
                Console.WriteLine($"Entering GridLoadData() with LoadDataArgs: {args.ToJson()}");
                StringSearchCriteria criteria = new
                (
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    2,
                    10
                );

                Dispatcher!.Dispatch(new GetDepartmentsAction(criteria));
                departmentGrid!.CurrentPage = currentPage + 1;
                Console.WriteLine($"CurrentPage after: {currentPage}");
                await InvokeAsync(StateHasChanged);
                // await Task.CompletedTask;

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
    }
}