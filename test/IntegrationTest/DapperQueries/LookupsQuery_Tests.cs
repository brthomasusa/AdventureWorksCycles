using AWC.Infrastructure.Persistence.Queries.Lookups;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.Lookups;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.DapperQueries
{
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
    }
}