using AWC.Application.Features.HumanResources.Common;
using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Core.HumanResources;
using AWC.Core.Shared;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.SharedKernel.Utilities;
using MapsterMapper;

namespace AWC.IntegrationTests.Repositories
{
    [Collection("Database Test")]
    public class EmployeeWriteRepository_Tests : TestBase
    {
        private readonly IWriteRepositoryManager _writeRepository;
        private readonly IMapper _mapper = AWC.IntegrationTest.AddMapsterForUnitTests.GetMapper();

        public EmployeeWriteRepository_Tests()
            => _writeRepository =
                new WriteRepositoryManager
                (
                    _dbContext,
                    new NullLogger<WriteRepositoryManager>(),
                    _mapper
                );

        [Fact]
        public async Task GetById_EmployeeWriteRepo_ShouldSucceed()
        {
            Result<Employee> result = await _writeRepository.EmployeeAggregateRepository.GetByIdAsync(4);

            Assert.True(result.IsSuccess);

            Assert.True(result.Value.Addresses.Any());
            Assert.True(result.Value.EmailAddresses.Any());
            Assert.True(result.Value.Telephones.Any());
            Assert.True(result.Value.DepartmentHistories.Any());
            Assert.True(result.Value.PayHistories.Any());
        }

        [Fact]
        public async Task InsertAsync_EmployeeWriteRepo_ShouldSucceed()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            Result<Employee> employeeResult = BuildEmployeeDomainObject.Build(command, _mapper);

            Result<int> result = await _writeRepository.EmployeeAggregateRepository.InsertAsync(employeeResult.Value);

            Assert.True(result.IsSuccess);
        }

        [Fact(Skip = "Why not")]
        public async Task Update_EmployeeWriteRepo_ShouldSucceed()
        {
            Result<Employee> getResult = await _writeRepository.EmployeeAggregateRepository.GetByIdAsync(16);

            Assert.True(getResult.IsSuccess);

            Result<Employee> updateResult =
                getResult.Value.Update("EM", NameStyle.Western, "Mr.", "Jabu", "Jabi", "J", "Sr.",
                                        EmailPromotion.None, "98765432", @"adventure-works\jabi", "Big Dog",
                                        new DateOnly(2000, 1, 31), "M", "M", new DateOnly(2018, 5, 4), true, 5, 1, true);

            Assert.True(updateResult.IsSuccess);

            Result<int> saveResult = await _writeRepository.EmployeeAggregateRepository.Update(updateResult.Value);

            Assert.True(saveResult.IsSuccess);

            getResult = await _writeRepository.EmployeeAggregateRepository.GetByIdAsync(16);
            Assert.Equal(@"adventure-works\jabi", getResult.Value.LoginID);
        }

        [Fact]
        public async Task Delete_Employee_EmployeeWriteRepo_ShouldSucceed()
        {
            Result<int> deleteResult = await _writeRepository.EmployeeAggregateRepository.Delete(4);

            Assert.True(deleteResult.IsSuccess);

            Result<Employee> test = await _writeRepository.EmployeeAggregateRepository.GetByIdAsync(4);
            Assert.True(test.IsFailure);
        }

        private static Employee GetEmployeeForCreate_ValidData()
        {
            Result<Employee> result = Employee.Create
                (
                    0,
                    "EM",
                    NameStyle.Western,
                    "Mr",
                    "John",
                    "Doe",
                    "D",
                    "Senior",
                    0,
                    "358987145",
                    "adventure-works\\john10",
                    "Tool Designer",
                    new DateOnly(1990, 2, 21),
                    "M",
                    "M",
                    new DateOnly(2023, 1, 5),
                    true,
                    0,
                    0,
                    true
                );

            return result.Value;
        }
    }
}