using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.DapperQueries
{
    public class EmployeeQuery_Tests : TestBase
    {
        [Fact]
        public async Task Query_GetEmployeeDetailsByIdWithAllInfoQuery_ShouldSucceed()
        {
            Result<EmployeeDetailReadModel> result =
                await GetEmployeeDetailsByIdWithAllInfoQuery.Query(1, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Query_GetEmployeeDetailsByIdWithAllInfoQuery_ShouldFail_WhenPassedInvalidID()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<ReadRepositoryManager>();
            Result<EmployeeDetailReadModel> result = await GetEmployeeDetailsByIdWithAllInfoQuery.Query(300, _dapperCtx, logger);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task Query_GetEmployeeListItemsQuery_ShouldSucceed()
        {
            const string lastName = "A";
            PagingParameters pagingParameters = new(1, 10);

            Result<PagedList<EmployeeListItemReadModel>> result =
                await GetEmployeeListItemsQuery.Query(lastName, pagingParameters, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int employees = result.Value.Count;
            Assert.Equal(10, employees);
        }

        [Fact]
        public async Task Query_GetEmployeeListItemsQuery_EmptySearchString_ShouldSucceed()
        {
            string lastName = string.Empty;
            PagingParameters pagingParameters = new(1, 5);

            Result<PagedList<EmployeeListItemReadModel>> result =
                await GetEmployeeListItemsQuery.Query(lastName, pagingParameters, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int employees = result.Value.Count;
            Assert.Equal(5, employees);
        }

    }
}
