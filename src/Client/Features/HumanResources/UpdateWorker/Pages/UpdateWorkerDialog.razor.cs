using System.Text.RegularExpressions;
using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Utilities;
using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace AWC.Client.Features.HumanResources.UpdateWorker.Pages
{
    public partial class UpdateWorkerDialog : ComponentBase
    {
        // SimpleLookups
        private static IEnumerable<MaritalStatuses> MaritalStatuses => SimpleLookups.GetMaritalStatuses();
        private static IEnumerable<Gender> Genders => SimpleLookups.GetGenders();
        private static IEnumerable<NameStyle> NameStyles => SimpleLookups.GetNameStyles();
        private static IEnumerable<EmailPromotionPreference> EmailPromotionPreferences => SimpleLookups.GetEmailPromotionPreference();
        private static IEnumerable<PhoneNumberType> PhoneNumberTypes => SimpleLookups.GetPhoneNumberTypes();
        private static IEnumerable<SalariedFlag> SalariedFlags => SimpleLookups.GetSalariedFlags();

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic>? Attributes { get; set; }
        [Parameter] public dynamic? BusinessEntityID { get; set; }

        private bool isLoading;
        private EmployeeGenericCommand? employee;
        private List<ManagerId>? managers;
        private List<StateCode>? stateCodes;
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

            Result<EmployeeGenericCommand> result = await EmployeeRepository!.GetEmployeeForUpdate(BusinessEntityID);

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
                Console.WriteLine($"employee: {employee.ToJson()}");
            }

            await LoadLookups();

            isLoading = false;
        }

        protected async Task LoadLookups()
        {
            Result<List<ManagerId>> managerResult = await EmployeeRepository!.GetManagerIDs();
            if (managerResult.IsFailure)
            {
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    managerResult.Error.Message
                );
            }

            managers = managerResult.Value;

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

        protected async Task FormSubmit()
        {
            try
            {
                Result result = await EmployeeRepository!.UpdateEmployee(employee!);

                if (result.IsSuccess)
                {
                    DialogService!.Close(employee);
                }
                else
                {
                    ShowErrorNotification.ShowError(
                        NotificationService!,
                        result.Error.Message
                    );
                }

            }
            catch (System.Exception ex)
            {
                ShowErrorNotification.ShowError(
                    NotificationService!,
                    Helpers.GetExceptionMessage(ex)
                );
            }
        }

        protected void CloseUpdateWorkerDialog()
            => DialogService!.Close(null);

        private bool ValidateBirthday(DateTime birthdate)
        {
            return birthdate >= new DateTime(1930, 1, 1) &&
                   birthdate <= DateTime.Today.AddYears(-18);
        }

        private bool ValidateHireDate(DateTime hireDate)
        {
            return hireDate >= new DateTime(1996, 7, 1) &&
                   hireDate <= DateTime.Today.AddDays(1);
        }

        private bool ValidateSelectedStateCode(int stateProvinceId)
        {
            StateCode? stateCode = stateCodes!.Find(s => s.StateProvinceID == stateProvinceId);

            return stateCode is not null;
        }

        private bool ValidateNationalIdNumber(string nationalId)
        {
            Regex regex = nationalIdRegex();
            Match match = regex.Match(nationalId ?? string.Empty);

            return match.Success;
        }

        [GeneratedRegex("^\\d{5,9}$")]
        private static partial Regex nationalIdRegex();


    }
}