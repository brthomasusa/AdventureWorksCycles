using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.DapperQueries
{
    public class EmployeeQuery_Tests : TestBase
    {
        [Fact]
        public async Task Query_GetEmployeeDetailsQuery_ShouldSucceed()
        {
            Result<EmployeeDetails> result =
                await GetEmployeeDetailsQuery.Query(1, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Query_GetEmployeeDetailsQuery_ShouldFail_WhenPassedInvalidID()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<ReadRepositoryManager>();
            Result<EmployeeDetails> result = await GetEmployeeDetailsQuery.Query(300, _dapperCtx, logger);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task Query_GetEmployeeCommandQuery_ShouldSucceed()
        {
            Result<EmployeeGenericCommand> result =
                await GetEmployeeGenericCommandQuery.Query(1, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Query_GetEmployeeListItemsQuery_ShouldSucceed()
        {
            StringSearchCriteria criteria = new("[LastName]", "Du", "[LastName]", 1, 10, 0, 10);
            Result<PagedList<EmployeeListItem>> result =
                await GetEmployeeListItemsQuery.Query(criteria, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int employees = result.Value.Count;
            Assert.Equal(4, employees);
        }

        [Fact]
        public async Task Query_GetEmployeeListItemsQuery_EmptySearchField_ShouldSucceed()
        {
            StringSearchCriteria criteria = new(string.Empty, "Du", "[LastName]", 1, 10, 0, 10);

            Result<PagedList<EmployeeListItem>> result =
                await GetEmployeeListItemsQuery.Query(criteria, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int employees = result.Value.Count;
            Assert.Equal(10, employees);
        }

        [Fact]
        public async Task Query_GetEmployeeListItemsQuery_EmptySearchString_ShouldSucceed()
        {
            StringSearchCriteria criteria = new("[LastName]", string.Empty, "[LastName]", 1, 10, 0, 10);

            Result<PagedList<EmployeeListItem>> result =
                await GetEmployeeListItemsQuery.Query(criteria, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int employees = result.Value.Count;
            Assert.Equal(10, employees);
        }

    }
}
