using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Services;
using AWC.Client.Services.HumanResources;
using AWC.Client.Utilities;
using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Shared;
using Grpc.Net.Client;
using MapsterMapper;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;

namespace AWC.Client.Features.HumanResources.CreateWorker.Pages
{
    public partial class CreateWorkerDialog : ComponentBase
    {
        private IEnumerable<MaritalStatuses>? maritalStatuses;
        private IEnumerable<Gender>? genders;
        private IEnumerable<NameStyle>? nameStyles;
        private bool isLoading;
        private EmployeeGenericCommand? employee = new();
        private List<StateCode>? stateCodes;

        [Inject] private DialogService? DialogService { get; set; }
        [Inject] private NotificationService? NotificationService { get; set; }
        [Inject] private IEmployeeRepositoryService? EmployeeRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Load();
        }

        protected async Task Load()
        {
            isLoading = true;

            maritalStatuses = new MaritalStatuses[] {
                new MaritalStatuses(){ Id = "M" , Status = "Married"},
                new MaritalStatuses() { Id = "S" , Status = "Single"}
            };

            genders = new Gender[] {
                new Gender(){ Id = "M" , Name = "Male"},
                new Gender() { Id = "F" , Name = "Female"}
            };

            nameStyles = new NameStyle[]
            {
                new NameStyle() {Id = 0, Name = "Western"},
                new NameStyle() {Id = 1, Name = "Eastern"}
            };

            employee = employee = new();

            Result<List<StateCode>> result = await EmployeeRepository!.GetStateCodes();
            if (result.IsFailure)
            {
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    result.Error.Message
                );
            }

            stateCodes = result.Value;
            Console.WriteLine($"{stateCodes.Count} StateCodes were returned.");

            isLoading = false;
            await Task.CompletedTask;
        }

        protected async Task FormSubmit(EmployeeGenericCommand args)
        {
            try
            {

                DialogService!.Close(employee);
                await Task.CompletedTask;
            }
            catch (System.Exception ex)
            {
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    Helpers.GetExceptionMessage(ex)
                );
            }
        }

        protected void CloseCreateWorkerDialog(MouseEventArgs args)
            => DialogService!.Close(null);
    }

    public class NameStyle
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class MaritalStatuses
    {
        public string? Id { get; set; }
        public string? Status { get; set; }
    }

    public class Gender
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}