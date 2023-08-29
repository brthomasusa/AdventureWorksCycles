using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Services;
using AWC.Client.Services.HumanResources;
using AWC.Client.Utilities;
using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.Lookups.HumanResources;
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
        private readonly IEnumerable<MaritalStatuses> maritalStatuses = new MaritalStatuses[] {
                new MaritalStatuses() { Id = "M" , Status = "Married"},
                new MaritalStatuses() { Id = "S" , Status = "Single"}};

        private readonly IEnumerable<Gender> genders = new Gender[] {
                new Gender() { Id = "M" , Name = "Male"},
                new Gender() { Id = "F" , Name = "Female"}};

        private readonly IEnumerable<NameStyle> nameStyles = new NameStyle[]
            {
                new NameStyle() { Id = 0, Name = "Western"},
                new NameStyle() { Id = 1, Name = "Eastern"}};

        private EmployeeGenericCommand employee = new();
        private List<StateCode>? stateCodes;
        private List<ManagerId>? managers;

        [Inject] private DialogService? DialogService { get; set; }
        [Inject] private NotificationService? NotificationService { get; set; }
        [Inject] private IEmployeeRepositoryService? EmployeeRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Load();
            await base.OnInitializedAsync();
        }

        protected async Task Load()
        {
            Result<List<StateCode>> stateCodeResult = await EmployeeRepository!.GetStateCodes();
            if (stateCodeResult.IsFailure)
            {
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    stateCodeResult.Error.Message
                );
            }

            stateCodes = stateCodeResult.Value;

            Result<List<ManagerId>> managerResult = await EmployeeRepository!.GetManagerIDs();
            if (managerResult.IsFailure)
            {
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    managerResult.Error.Message
                );
            }

            managers = managerResult.Value;

            employee.Active = true;
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