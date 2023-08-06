using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Shared.Commands.HumanResources;
using FluentValidation;
using FluentValidation.TestHelper;

namespace AWC.UnitTest.FluentValidators.HumanResources
{
    public class DepartmentistoryCommandCreateValidatorTest
    {
        private DepartmentHistoryCommandCreateValidator _departmentHistoryValidator;

        public DepartmentistoryCommandCreateValidatorTest()
            => _departmentHistoryValidator = new DepartmentHistoryCommandCreateValidator();
    }
}