using AWC.Application.BusinessRules.HumanResources;
using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTest.Validation.HumanResources
{
    [Collection("Database Test")]
    public class EmployeeBusinessRule_Tests : TestBase
    {
        private readonly IValidationRepositoryManager _validationRepository;

        public EmployeeBusinessRule_Tests()
            => _validationRepository = new ValidationRepositoryManager(_dbContext, new NullLogger<WriteRepositoryManager>());

        [Fact]
        public async Task Validate_CreateEmployeeDepartmentMustExist_ValidData_ShouldReturnTrue()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            CreateEmployeeDepartmentMustExist verifyDeptExistRule = new(_validationRepository);

            ValidationResult validationResult = await verifyDeptExistRule.Validate(command);

            Assert.True(validationResult.IsValid);
        }

        [Fact]
        public async Task Validate_CreateEmployeeDepartmentMustExist_InvalidID_ShouldReturnFalse()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_InvalidDepartmentID();
            CreateEmployeeDepartmentMustExist verifyDeptExistRule = new(_validationRepository);

            ValidationResult validationResult = await verifyDeptExistRule.Validate(command);

            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public async Task Validate_CreateEmployeeShiftMustExist_ValidID_ShouldReturnTrue()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            CreateEmployeeShiftMustExist verifyShiftExistRule = new(_validationRepository);

            ValidationResult validationResult = await verifyShiftExistRule.Validate(command);

            Assert.True(validationResult.IsValid);
        }

        [Fact]
        public async Task Validate_CreateEmployeeShiftMustExist_InvalidID_ShouldReturnFalse()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_InvalidShiftID();
            CreateEmployeeShiftMustExist verifyShiftExistRule = new(_validationRepository);

            ValidationResult validationResult = await verifyShiftExistRule.Validate(command);

            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public async Task Validate_CreateEmployeeManagerMustExist_ValidID_ShouldReturnTrue()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            CreateEmployeeManagerMustExist verifyMgrExistRule = new(_validationRepository);

            ValidationResult validationResult = await verifyMgrExistRule.Validate(command);

            Assert.True(validationResult.IsValid);
        }

        [Fact]
        public async Task Validate_CreateEmployeeManagerMustExist_InvalidID_ShouldReturnFalse()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_InvalidManagerID();
            CreateEmployeeManagerMustExist verifyMgrExistRule = new(_validationRepository);

            ValidationResult validationResult = await verifyMgrExistRule.Validate(command);

            Assert.False(validationResult.IsValid);
        }
    }
}