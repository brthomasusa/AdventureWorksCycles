using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTest.Validation.HumanResources
{
    [Collection("Database Test")]
    public class EmployeeBusinessRuleValidator_Tests : TestBase
    {
        private readonly IValidationRepositoryManager _validationRepository;

        public EmployeeBusinessRuleValidator_Tests()
            => _validationRepository = new ValidationRepositoryManager(_dbContext, new NullLogger<WriteRepositoryManager>());

        [Fact]
        public async Task Validate_CreateEmployeeBusinessRuleValidator_ValidData_ShouldReturnTrue()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            CreateEmployeeBusinessRuleValidator businessRuleValidator = new(_validationRepository);

            Result validationResult = await businessRuleValidator.Validate(command);

            Assert.True(validationResult.IsSuccess);
        }

        [Fact]
        public async Task Validate_CreateEmployeeBusinessRuleValidator_DupeEmployeeName_ShouldReturnFalse()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_DupeEmployeeName();
            CreateEmployeeBusinessRuleValidator businessRuleValidator = new(_validationRepository);

            Result validationResult = await businessRuleValidator.Validate(command);

            Assert.True(validationResult.IsFailure);
        }

        [Fact]
        public async Task Validate_CreateEmployeeBusinessRuleValidator_DupeNationalID_ShouldReturnFalse()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_DupeNationalID();
            CreateEmployeeBusinessRuleValidator businessRuleValidator = new(_validationRepository);

            Result validationResult = await businessRuleValidator.Validate(command);

            Assert.True(validationResult.IsFailure);
        }

        [Fact]
        public async Task Validate_CreateEmployeeBusinessRuleValidator_DupeEmail_ShouldReturnFalse()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_DupeEmail();
            CreateEmployeeBusinessRuleValidator businessRuleValidator = new(_validationRepository);

            Result validationResult = await businessRuleValidator.Validate(command);

            Assert.True(validationResult.IsFailure);
        }

        [Fact]
        public async Task Validate_CreateEmployeeBusinessRuleValidator_InvalidDepartmentID_ShouldReturnFalse()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_InvalidDepartmentID();
            CreateEmployeeBusinessRuleValidator businessRuleValidator = new(_validationRepository);

            Result validationResult = await businessRuleValidator.Validate(command);

            Assert.True(validationResult.IsFailure);
        }

        [Fact]
        public async Task Validate_CreateEmployeeBusinessRuleValidator_InvalidShiftID_ShouldReturnFalse()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_InvalidShiftID();
            CreateEmployeeBusinessRuleValidator businessRuleValidator = new(_validationRepository);

            Result validationResult = await businessRuleValidator.Validate(command);

            Assert.True(validationResult.IsFailure);
        }

        [Fact]
        public async Task Validate_CreateEmployeeBusinessRuleValidator_InvalidManagerID_ShouldReturnFalse()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_InvalidManagerID();
            CreateEmployeeBusinessRuleValidator businessRuleValidator = new(_validationRepository);

            Result validationResult = await businessRuleValidator.Validate(command);

            Assert.True(validationResult.IsFailure);
        }









    }
}