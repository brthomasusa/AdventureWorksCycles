using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Services;
using AWC.Client.Services.HumanResources;
using AWC.Client.Utilities;
using AWC.Shared.Queries.HumanResources;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Shared;
using Grpc.Net.Client;
using MapsterMapper;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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

        protected EmployeeDetails? Employee
        {
            get
            {
                return employee;
            }
            set
            {
                if (!object.Equals(employee, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "employee", NewValue = value, OldValue = employee };
                    employee = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        protected void CloseEmployeeDetailsDialog(MouseEventArgs args)
        {
            DialogService!.Close(null);
        }
    }
}