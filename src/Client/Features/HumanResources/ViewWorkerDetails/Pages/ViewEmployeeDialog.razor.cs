using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Utilities;
using AWC.Shared.Queries.HumanResources;

using Microsoft.AspNetCore.Components;
using Radzen;

namespace AWC.Client.Features.HumanResources.ViewWorkerDetails.Pages
{
    public partial class ViewEmployeeDialog : ComponentBase
    {
        private bool isLoading;
        private EmployeeDetails? employee;

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic>? Attributes { get; set; }
        [Parameter] public dynamic? BusinessEntityID { get; set; }
        [Inject] private DialogService? DialogService { get; set; }
        [Inject] private NotificationService? NotificationService { get; set; }
        [Inject] private IEmployeeRepositoryService? EmployeeRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Load();
            await base.OnInitializedAsync();
        }

        private async Task Load()
        {
            isLoading = true;

            Result<EmployeeDetails> result = await EmployeeRepository!.GetEmployeeDetails(BusinessEntityID);

            if (result.IsFailure)
            {
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    result.Error.Message
                );
            }
            else
            {
                employee = result.Value;
            }

            isLoading = false;
        }

        protected void CloseEmployeeDetailsDialog()
        {
            DialogService!.Close(null);
        }
    }
}