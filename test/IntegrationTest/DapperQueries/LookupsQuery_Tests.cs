using AWC.Infrastructure.Persistence.Queries.Lookups;
using AWC.Infrastructure.Persistence.Queries.Lookups.HumanResources;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.DapperQueries
{
    [Collection("Database Test")]
    public class LookupsQuery_Tests : TestBase
    {
        [Fact]
        public async Task Query_GetStateCodeIdForUSAQuery_ShouldSucceed()
        {
            Result<List<StateCode>> result = await GetStateCodeIdUSAQuery.Query(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Query_GetStateCodeIdForAllQuery_ShouldSucceed()
        {
            Result<List<StateCode>> result = await GetStateCodeIdAllQuery.Query(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Query_GetDepartmentIdQuery_ShouldSucceed()
        {
            Result<List<DepartmentId>> result = await GetDepartmentIdsQuery.Query(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Query_GetShiftIdQuery_ShouldSucceed()
        {
            Result<List<ShiftId>> result = await GetShiftIdsQuery.Query(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Query_GetManagerIdsQuery_ShouldSucceed()
        {
            Result<List<ManagerId>> result = await GetManagerIdsQuery.Query(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Assert.True(result.IsSuccess);
        }
    }
}