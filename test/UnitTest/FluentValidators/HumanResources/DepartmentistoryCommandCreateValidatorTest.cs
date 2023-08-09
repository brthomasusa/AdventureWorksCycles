using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Shared.Commands.HumanResources;
using FluentValidation;
using FluentValidation.TestHelper;

namespace AWC.UnitTest.FluentValidators.HumanResources
{
    public class DepartmentistoryCommandCreateValidatorTest
    {
        private readonly DepartmentHistoryCommandCreateValidator _departmentHistoryValidator;

        public DepartmentistoryCommandCreateValidatorTest()
            => _departmentHistoryValidator = new();

        [Fact]
        public void DepartmentHistoryCommandCreateValidator_ValidData_ShouldSucceed()
        {
            DepartmentHistoryCommand command = new()
            {
                BusinessEntityID = 0,
                DepartmentID = 16,
                ShiftID = 1,
                StartDate = new DateTime(2023, 8, 6)
            };

            var result = _departmentHistoryValidator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void DepartmentHistoryCommandCreateValidator_InvalidDepartmentID_ShouldFail()
        {
            DepartmentHistoryCommand command = new()
            {
                BusinessEntityID = 0,
                DepartmentID = 0,
                ShiftID = 1,
                StartDate = new DateTime(2023, 8, 6)
            };

            var result = _departmentHistoryValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.DepartmentID);
        }

        [Fact]
        public void DepartmentHistoryCommandCreateValidator_InvalidShiftID_ShouldFail()
        {
            DepartmentHistoryCommand command = new()
            {
                BusinessEntityID = 0,
                DepartmentID = 16,
                ShiftID = 0,
                StartDate = new DateTime(2023, 8, 6)
            };

            var result = _departmentHistoryValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.ShiftID);
        }

        [Fact]
        public void DepartmentHistoryCommandCreateValidator_InvalidStartDate_ShouldFail()
        {
            DepartmentHistoryCommand command = new()
            {
                BusinessEntityID = 0,
                DepartmentID = 16,
                ShiftID = 1,
                StartDate = new DateTime()
            };

            var result = _departmentHistoryValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.StartDate);
        }

        [Fact]
        public void DepartmentHistoryCommandCreateValidator_NotNullEndDate_ShouldFail()
        {
            DepartmentHistoryCommand command = new()
            {
                BusinessEntityID = 0,
                DepartmentID = 16,
                ShiftID = 1,
                StartDate = new DateTime(2023, 8, 6),
                EndDate = new DateTime(2023, 8, 6)
            };

            var result = _departmentHistoryValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.EndDate);
        }

        [Fact]
        public void DepartmentHistoryCommandCreateValidator_DefaultEndDate_ShouldSucceed()
        {
            DepartmentHistoryCommand command = new()
            {
                BusinessEntityID = 0,
                DepartmentID = 16,
                ShiftID = 1,
                StartDate = new DateTime(2023, 8, 6),
                EndDate = null
            };

            var result = _departmentHistoryValidator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}