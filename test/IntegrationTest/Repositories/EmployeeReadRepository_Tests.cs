using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.Repositories
{
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
    }
}