using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.Repositories
{
    [Collection("Database Test")]
    public class EmployeeReadRepository_Tests : TestBase
    {
        [Fact]
        public async Task GetEmployeeDetails_EmployeeReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());

            Result<EmployeeDetails> result =
                await readRepository.EmployeeReadRepository.GetEmployeeDetails(1);

            Assert.True(result.IsSuccess);
            Assert.Equal("Sánchez", result.Value.LastName);
        }

        [Fact]
        public async Task GetEmployeeCommand_EmployeeReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());

            Result<EmployeeGenericCommand> result =
                await readRepository.EmployeeReadRepository.GetEmployeeGenericCommand(1);

            Assert.True(result.IsSuccess);
            Assert.Equal("Sánchez", result.Value.LastName);
        }

        [Fact]
        public async Task GetEmployeeDetails_EmployeeReadRepository_WithInvalidID_ShouldFail()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());

            Result<EmployeeDetails> result =
                await readRepository.EmployeeReadRepository.GetEmployeeDetails(300);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task GetEmployeeListItemsSearchByLastName_EmployeeReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());

            StringSearchCriteria criteria = new("[LastName]", "A", "[LastName]", 1, 10, 0, 10);
            Result<PagedList<EmployeeListItem>> result =
                await readRepository.EmployeeReadRepository.GetEmployeeListItemsSearchByLastName(criteria);

            Assert.True(result.IsSuccess);
            int employees = result.Value.Count;
            Assert.Equal(10, employees);
        }

        [Fact]
        public async Task GetDepartmentHistories_EmployeeReadRepository_WithInvalidID_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());

            Result<List<DepartmentHistory>> result =
                await readRepository.EmployeeReadRepository.GetDepartmentHistories(16);

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Count == 2);
        }

        [Fact]
        public async Task GetDepartmentHistoryCommands_EmployeeReadRepository_WithInvalidID_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());

            Result<List<DepartmentHistoryCommand>> result =
                await readRepository.EmployeeReadRepository.GetDepartmentHistoryCommands(16);

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Count == 2);
        }

        [Fact]
        public async Task GetPayHistories_EmployeeReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());

            Result<List<PayHistory>> result =
                await readRepository.EmployeeReadRepository.GetPayHistories(16);

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Count == 3);
        }

        [Fact]
        public async Task GetPayHistoryCommands_EmployeeReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());

            Result<List<PayHistoryCommand>> result =
                await readRepository.EmployeeReadRepository.GetPayHistoryCommands(16);

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Count == 3);
        }

        [Fact]
        public async Task GetDepartmentHistories_EmployeeReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());

            Result<List<DepartmentHistory>> result =
                await readRepository.EmployeeReadRepository.GetDepartmentHistories(16);

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Count == 2);
        }

        [Fact]
        public async Task GetDepartmentHistoryCommands_EmployeeReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());

            Result<List<DepartmentHistoryCommand>> result =
                await readRepository.EmployeeReadRepository.GetDepartmentHistoryCommands(16);

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Count == 2);
        }
    }
}