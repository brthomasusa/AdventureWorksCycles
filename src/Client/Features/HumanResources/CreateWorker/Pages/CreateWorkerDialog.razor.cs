using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Utilities;
using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;

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
        private List<DepartmentId>? departments;
        private List<ManagerId>? managers;
        private List<ShiftId>? shifts;
        private List<StateCode>? stateCodes;


        [Inject] private DialogService? DialogService { get; set; }
        [Inject] private NotificationService? NotificationService { get; set; }
        [Inject] private IEmployeeRepositoryService? EmployeeRepository { get; set; }
        [Inject] private ICompanyRepositoryService? CompanyRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Load();
            await base.OnInitializedAsync();
        }

        protected async Task Load()
        {
            Result<List<DepartmentId>> departmentResult = await CompanyRepository!.GetDepartmentIDs();
            if (departmentResult.IsFailure)
            {
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    departmentResult.Error.Message
                );
            }

            departments = departmentResult.Value;

            Result<List<ManagerId>> managerResult = await EmployeeRepository!.GetManagerIDs();
            if (managerResult.IsFailure)
            {
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    managerResult.Error.Message
                );
            }

            managers = managerResult.Value;

            Result<List<ShiftId>> shiftResult = await CompanyRepository!.GetShiftIDs();
            if (shiftResult.IsFailure)
            {
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    shiftResult.Error.Message
                );
            }

            shifts = shiftResult.Value;

            Result<List<StateCode>> stateCodeResult = await EmployeeRepository!.GetStateCodes();
            if (stateCodeResult.IsFailure)
            {
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    stateCodeResult.Error.Message
                );
            }

            stateCodes = stateCodeResult.Value;

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