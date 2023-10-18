using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTest.Repositories
{
    [Collection("Database Test")]
    public class EmployeeValidationRepository_Tests : TestBase
    {
        private readonly IValidationRepositoryManager _validationRepository;

        public EmployeeValidationRepository_Tests()
            => _validationRepository = new ValidationRepositoryManager(_dbContext, new NullLogger<WriteRepositoryManager>());

        [Fact]
        public async Task ValidatePersonNameIsUnique_EmployeeValidationRepo_NewRecord_ShouldReturnTrue()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidatePersonNameIsUnique(0, "Henry", "Jones", "Z");

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task ValidatePersonNameIsUnique_EmployeeValidationRepo_EditingExistingWithoutNameChange_ShouldReturnTrue()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidatePersonNameIsUnique(25, "James", "Hamilton", "R");

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task ValidatePersonNameIsUnique_EmployeeValidationRepo_EditingExistingNameChangeWouldCauseDupe_ShouldReturnFalse()
        {
            // EmployeeID 2 is Terri Lee Duffy, changing name to James R Hamilton would be a duplicate name of EmployeeID 25
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidatePersonNameIsUnique(2, "James", "Hamilton", "R");

            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task ValidateNationalIdNumberIsUnique_EmployeeValidationRepo_NewRecord_ShouldReturnTrue()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidateNationalIdNumberIsUnique(0, "632145877");

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task ValidateNationalIdNumberIsUnique_EmployeeValidationRepo_EditingExistingWithoutNatlIDChange_ShouldReturnTrue()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidateNationalIdNumberIsUnique(2, "245797967");

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task ValidateNationalIdNumberIsUnique_EmployeeValidationRepo_EditingExistingWithNatlIDChange_ShouldReturnFalse()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidateNationalIdNumberIsUnique(1, "245797967");

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task ValidateEmployeeEmailIsUnique_EmployeeValidationRepo_NewRecord_ShouldReturnTrue()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidateEmployeeEmailIsUnique(0, "david4@adventure-works.com");

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task ValidateEmployeeEmailIsUnique_EmployeeValidationRepo_EditingExistingWithoutEmailChange_ShouldReturnTrue()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidateEmployeeEmailIsUnique(16, "david0@adventure-works.com");

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task ValidateEmployeeEmailIsUnique_EmployeeValidationRepo_EditingExistingWithEmailChange_ShouldReturnFalse()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidateEmployeeEmailIsUnique(25, "david0@adventure-works.com");

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task ValidateDepartmentExist_EmployeeValidationRepo_NewEmployeeDeptAssignment_ValidID_ShouldReturnTrue()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidateDepartmentExist(16);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task ValidateDepartmentExist_EmployeeValidationRepo_NewEmployeeDeptAssignment_InvalidID_ShouldReturnFalse()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidateDepartmentExist(56);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task ValidateShiftExist_EmployeeValidationRepo_NewEmployeeShiftAssignment_ValidID_ShouldReturnTrue()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidateShiftExist(1);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task ValidateShiftExist_EmployeeValidationRepo_NewEmployeeShiftAssignment_InvalidID_ShouldReturnFalse()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidateShiftExist(11);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task ValidateManagerExist_EmployeeValidationRepo_NewEmployeeMgrAssignment_ValidID_ShouldReturnTrue()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidateManagerExist(1);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task ValidateManagerExist_EmployeeValidationRepo_NewEmployeeMgrAssignment_InvalidID_ShouldReturnTrue()
        {
            Result result = await _validationRepository.EmployeeAggregateRepository.ValidateManagerExist(1012);

            Assert.True(result.IsFailure);
        }
    }
}