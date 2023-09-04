using System.Text.RegularExpressions;
using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Utilities;
using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace AWC.Client.Features.HumanResources.CreateWorker.Pages
{
    public partial class CreateWorkerDialog : ComponentBase
    {
        // SimpleLookups
        private static IEnumerable<MaritalStatuses> MaritalStatuses => SimpleLookups.GetMaritalStatuses();
        private static IEnumerable<Gender> Genders => SimpleLookups.GetGenders();
        private static IEnumerable<NameStyle> NameStyles => SimpleLookups.GetNameStyles();
        private static IEnumerable<EmailPromotionPreference> EmailPromotionPreferences => SimpleLookups.GetEmailPromotionPreference();
        private static IEnumerable<PhoneNumberType> PhoneNumberTypes => SimpleLookups.GetPhoneNumberTypes();
        private static IEnumerable<PayFrequency> PayFrequencies => SimpleLookups.GetPayFrequencies();
        private static IEnumerable<SalariedFlag> SalariedFlags => SimpleLookups.GetSalariedFlags();

        private const int UNSELECTED = -1;
        private double payRate;
        private int payFrequency = UNSELECTED;
        private int shiftId;
        private int departmentId;
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
            await LoadLookups();
            LoadEmployeeDefaults();

            await base.OnInitializedAsync();
        }

        protected async Task LoadLookups()
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
        }

        private void LoadEmployeeDefaults()
        {
            employee.NameStyle = UNSELECTED;
            employee.PhoneNumberType = UNSELECTED;
            employee.EmailPromotion = UNSELECTED;
            employee.VacationHours = -41;
            employee.SickLeaveHours = UNSELECTED;
            employee.Active = true;
        }

        protected async Task FormSubmit(EmployeeGenericCommand args)
        {
            try
            {
                Console.WriteLine($"FormSubmit called: {args.ToJson()}");
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

        protected void CloseCreateWorkerDialog()
            => DialogService!.Close(null);

        private void OnShiftChanged(object value)
        {
            Console.WriteLine($"Value changed to: {value.ToJson()}, shiftId: {shiftId}");
        }

        private bool ValidateSelectedManager(int managerId)
        {
            ManagerId? mgr = managers!.Find(m => m.BusinessEntityID == managerId);

            return mgr is not null;
        }

        private bool ValidateSelectedDepartmentID(int departmentId)
        {
            DepartmentId? department = departments!.Find(d => d.DepartmentID == departmentId);

            return department is not null;
        }

        private bool ValidateManagerAndEmployeeInSameDepartment(int managerId, int departmentId)
        {
            ManagerId? mgr = managers!.Find(m => m.BusinessEntityID == managerId &&
                                                 m.DepartmentID == departmentId);

            return mgr is not null;
        }

        private bool ValidateSelectedShiftID(int shiftId)
        {
            ShiftId? shift = shifts!.Find(d => d.ShiftID == shiftId);

            return shift is not null;
        }

        private bool ValidateSelectedStateCode(int stateProvinceId)
        {
            StateCode? stateCode = stateCodes!.Find(s => s.StateProvinceID == stateProvinceId);

            return stateCode is not null;
        }

        private bool validateNationalIdNumber(string nationalId)
        {


            Regex regex = nationalIdRegex();
            Match match = regex.Match(nationalId ?? string.Empty);

            return match.Success;
        }

        [GeneratedRegex("^\\d{5,9}$")]
        private static partial Regex nationalIdRegex();
    }
}