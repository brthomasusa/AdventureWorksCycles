using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Core.Entities.HumanResources.ValueObjects;
using AWC.Core.Entities.Shared;
using AWC.Core.Entities.Shared.EntityIDs;
using AWC.Core.Entities.Shared.ValueObjects;
using AWC.Core.Enums;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.Entities.HumanResources
{
    public class Employee : Person
    {
        private readonly List<DepartmentHistory> _deptHistories = new();
        private readonly List<PayHistory> _payHistories = new();

        protected Employee
        (
            EmployeeID employeeID,
            PersonType personType,
            NameStyle nameStyle,
            Title title,
            PersonName name,
            Suffix suffix,
            EmailPromotion emailPromotionEnum,
            EmployeeID managerID,
            NationalID nationalID,
            Login login,
            JobTitle jobTitle,
            DateOfBirth birthDate,
            MaritalStatus maritalStatus,
            Gender gender,
            DateOfHire hireDate,
            bool salaried,
            Vacation vacation,
            SickLeave sickLeave,
            EmploymentStatus active

        ) : base(new PersonID(employeeID.Value), personType, nameStyle, title, name, suffix, emailPromotionEnum)
        {
            ManagerID = managerID;
            NationalIDNumber = nationalID;
            LoginID = login;
            JobTitle = jobTitle;
            BirthDate = birthDate;
            MaritalStatus = maritalStatus;
            Gender = gender;
            HireDate = hireDate;
            IsSalaried = salaried;
            VacationHours = vacation;
            SickLeaveHours = sickLeave;
            IsActive = active;

            CheckValidity();
        }

        public static Result<Employee> Create
        (
            EmployeeID employeeID,
            string personType,
            NameStyle nameStyle,
            string? title,
            string firstName,
            string lastName,
            string? middleName,
            string? suffix,
            EmployeeID managerID,
            string nationalID,
            string login,
            string jobTitle,
            DateOnly birthDate,
            string maritalStatus,
            string gender,
            DateOnly hireDate,
            bool salaried,
            int vacation,
            int sickLeave,
            bool active
        )
        {
            try
            {
                Employee employee = new(
                    employeeID,
                    PersonType.Create(personType),
                    nameStyle,
                    Title.Create(title!),
                    PersonName.Create(lastName, firstName, middleName!),
                    Suffix.Create(suffix!),
                    EmailPromotion.None,
                    managerID,
                    NationalID.Create(nationalID),
                    Login.Create(login),
                    JobTitle.Create(jobTitle),
                    DateOfBirth.Create(birthDate),
                    MaritalStatus.Create(maritalStatus),
                    Gender.Create(gender),
                    DateOfHire.Create(hireDate),
                    salaried,
                    Vacation.Create(vacation),
                    SickLeave.Create(sickLeave),
                    EmploymentStatus.Create(active)
                );

                return employee;
            }
            catch (Exception ex)
            {
                return Result<Employee>.Failure<Employee>(new Error("Employee.Create", Helpers.GetExceptionMessage(ex)));
            }
        }

        public Result<Employee> Update
        (
            string personType,
            NameStyle nameStyle,
            string title,
            string firstName,
            string lastName,
            string middleName,
            string suffix,
            EmailPromotion emailPromotionEnum,
            string nationalID,
            string login,
            string jobTitle,
            DateOnly birthDate,
            string maritalStatus,
            string gender,
            DateOnly hireDate,
            bool salaried,
            int vacation,
            int sickLeave,
            bool active
        )
        {
            try
            {
                Result<Person> result = base.UpdatePerson(personType, nameStyle, title, firstName, lastName, middleName, suffix, emailPromotionEnum);

                if (result.IsFailure)
                    return Result<Employee>.Failure<Employee>(new Error("", result.Error.Message));

                NationalIDNumber = NationalID.Create(nationalID);
                LoginID = Login.Create(login);
                JobTitle = JobTitle.Create(jobTitle);
                BirthDate = DateOfBirth.Create(birthDate);
                MaritalStatus = MaritalStatus.Create(maritalStatus);
                Gender = Gender.Create(gender);
                HireDate = DateOfHire.Create(hireDate);
                IsSalaried = salaried;
                VacationHours = Vacation.Create(vacation);
                SickLeaveHours = SickLeave.Create(sickLeave);
                IsActive = EmploymentStatus.Create(active);

                CheckValidity();
                UpdateModifiedDate();
                return this;
            }
            catch (Exception ex)
            {
                return Result<Employee>.Failure<Employee>(new Error("Employee.Update", Helpers.GetExceptionMessage(ex)));
            }
        }

        public EmployeeID ManagerID { get; }

        public NationalID NationalIDNumber { get; private set; }

        public Login LoginID { get; private set; }

        public JobTitle JobTitle { get; private set; }

        public DateOfBirth BirthDate { get; private set; }

        public MaritalStatus MaritalStatus { get; private set; }

        public Gender Gender { get; private set; }

        public DateOfHire HireDate { get; private set; }

        public bool IsSalaried { get; private set; }

        public Vacation VacationHours { get; private set; }

        public SickLeave SickLeaveHours { get; private set; }

        public EmploymentStatus IsActive { get; private set; }

        public virtual IReadOnlyCollection<DepartmentHistory> DepartmentHistories => _deptHistories.AsReadOnly();

        public Result<DepartmentHistory> AddDepartmentHistory
        (
            DepartmentHistoryID id,
            DepartmentID departmentId,
            ShiftID shiftId,
            DateOnly startDate,
            DateOnly? endDate
        )
        {
            try
            {
                bool search = _deptHistories.Exists(deptHistory => deptHistory.DepartmentID.Value == departmentId.Value && deptHistory.ShiftID.Value == shiftId.Value && deptHistory.StartDate == startDate);

                if (search)
                    return Result<DepartmentHistory>.Failure<DepartmentHistory>(new Error("Employee.AddDepartmentHistory", "This is a duplicate department history."));

                Result<DepartmentHistory> result = DepartmentHistory.Create
                (
                    id,
                    departmentId,
                    shiftId,
                    startDate,
                    endDate
                );

                if (result.IsFailure)
                    return Result<DepartmentHistory>.Failure<DepartmentHistory>(new Error("Employee.AddDepartmentHistory", result.Error.Message));

                if (id.Value == 0)
                    result.Value.EntityStatus = EntityStatus.Added;

                _deptHistories.Add(result.Value);
                return result;
            }
            catch (Exception ex)
            {
                return Result<DepartmentHistory>.Failure<DepartmentHistory>(new Error("Employee.AddDepartmentHistory", Helpers.GetExceptionMessage(ex)));
            }
        }

        public virtual IReadOnlyCollection<PayHistory> PayHistories => _payHistories.AsReadOnly();

        public Result<PayHistory> AddPayHistory
        (
            PayHistoryID id,
            DateTime rateChangeDate,
            decimal rate,
            PayFrequency payFrequency
        )
        {
            try
            {
                bool found = _payHistories.Exists(pay => pay.Id.Value == id.Value && pay.RateChangeDate == rateChangeDate && pay.PayRate.Value.Amount == rate);

                if (found)
                    return Result<PayHistory>.Failure<PayHistory>(new Error("Employee.AddPayHistory", "This is a duplicate pay history."));

                Result<PayHistory> result = PayHistory.Create(id, rateChangeDate, rate, payFrequency);
                if (result.IsSuccess)
                {
                    if (id.Value == 0)
                        result.Value.EntityStatus = EntityStatus.Added;

                    _payHistories.Add(result.Value);
                    return result.Value;
                }
                else
                {
                    return Result<PayHistory>.Failure<PayHistory>(new Error("Employee.AddPayHistory", result.Error.Message));
                }
            }
            catch (Exception ex)
            {
                return Result<PayHistory>.Failure<PayHistory>(new Error("Employee.AddPayHistory", Helpers.GetExceptionMessage(ex)));
            }
        }

        protected override void CheckValidity()
        {

            if (!PersonType.Value!.Equals("EM", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Employee must be person type 'EM'.");
        }
    }
}