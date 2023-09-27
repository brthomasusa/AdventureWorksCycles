using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Shared.Commands.HumanResources;
using AWC.UnitTest.Data;
using FluentValidation;
using FluentValidation.TestHelper;

namespace AWC.UnitTest.FluentValidators.HumanResources
{
    public class CreateEmployeeCommandDataValidatorTest
    {
        private readonly CreateEmployeeDataValidator _employeeCreateValidator;

        public CreateEmployeeCommandDataValidatorTest()
            => _employeeCreateValidator = new();

        [Fact]
        public void CreateEmployeeCommandDataValidator_ValidData_ShouldSucceed()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_InvalidBusinessEntityID_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { BusinessEntityID = 1 };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.BusinessEntityID);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_LastNameEmptyString_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { LastName = string.Empty };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_InvalidEmailPromotion_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { EmailPromotion = 3 };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.EmailPromotion);
        }

        [Theory]
        [InlineData("1234")]
        [InlineData("1234567890")]
        [InlineData("1234-5678")]
        [InlineData("1234A5678")]
        [InlineData("1234.5678")]
        public void CreateEmployeeCommandDataValidator_InvalidNationalID_ShouldFail(string nationalId)
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { NationalIDNumber = nationalId };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.NationalIDNumber);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_BirthdayDefaultDate_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { BirthDate = new DateTime() };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.BirthDate);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_BirthdayTooOld_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { BirthDate = new DateTime(1929, 12, 31) };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.BirthDate);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_BirthdayTooYoung_ShouldFail()
        {
            DateTime birthday = DateTime.Now.AddYears(-18);
            birthday = birthday.AddDays(1);

            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { BirthDate = birthday };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.BirthDate);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_MaritalStatusIgnoreCase_ShouldSucceed()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { MaritalStatus = "s" };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldNotHaveValidationErrorFor(x => x.MaritalStatus);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_HireDateBefore_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { HireDate = new DateTime(1996, 6, 30) };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.HireDate);
        }

        [Theory]
        [InlineData(-41)]
        [InlineData(241)]
        public void CreateEmployeeCommandDataValidator_InvalidVacationHours_ShouldFail(int hours)
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { VacationHours = hours };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.VacationHours);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(121)]
        public void CreateEmployeeCommandDataValidator_InvalidSickLeaveHours_ShouldFail(int hours)
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { SickLeaveHours = hours };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.SickLeaveHours);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_EmployeeStatusInactive_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { Active = false };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Active);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_MissingManagerID_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { ManagerID = 0 };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.ManagerID);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_EmptyAddressLine1_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { AddressLine1 = string.Empty };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.AddressLine1);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_EmptyCity_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { City = string.Empty };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.City);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_EmptyPostalCode_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { PostalCode = string.Empty };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.PostalCode);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        public void CreateEmployeeCommandDataValidator_InvalidPhoneNumberType_ShouldFail(int phType)
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            command = command with { PhoneNumberTypeID = phType };

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.PhoneNumberTypeID);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_EmptyDepartmentHistoryList_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_EmptyDepartmentHistories();

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.DepartmentHistories);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_DepartmentHistoryListCountMoreThanOne_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_MultipleDepartmentHistories();

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.DepartmentHistories);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_EmptyPayHistoryList_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_EmptyPayHistories();

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.PayHistories);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_PayHistoryListCountMoreThanOne_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_MultiplePayHistories();

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.PayHistories);
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_EmpHireDateNotEqualToDeptStartDate_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_DeptStartDateNotEqualToHireDate();

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveAnyValidationError();
        }

        [Fact]
        public void CreateEmployeeCommandDataValidator_EmpHireDateNotEqualToPayRateChangeDate_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_PayHistoryPayRateChangeDateNotEqualToHireDate();

            var result = _employeeCreateValidator.TestValidate(command);
            result.ShouldHaveAnyValidationError();
        }

















    }
}