using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.DapperQueries
{
    public class CompanyQuery_Tests : TestBase
    {
        [Fact]
        public async Task Query_GetCompanyDetailsByIdQuery_ShouldSucceed()
        {
            Result<CompanyDetailsForDisplay> result = await GetCompanyDetailsQuery.Query(1, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Query_GetCompanyDetailsByIdQuery_ShouldFail_WhenPassedInvalidID()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<ReadRepositoryManager>();

            Result<CompanyDetailsForDisplay> result = await GetCompanyDetailsQuery.Query(100, _dapperCtx, logger);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task Query_GetCompanyCommandByIdQuery_ShouldSucceed()
        {
            Result<CompanyDetailsForEdit> result = await GetCompanyCommandQuery.Query(1, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Query_Query_GetCompanyCommandByIdQuery_ShouldFail_WhenPassedInvalidID()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<ReadRepositoryManager>();

            Result<CompanyDetailsForEdit> result = await GetCompanyCommandQuery.Query(100, _dapperCtx, logger);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task Query_GetCompanyDepartmentsQuery_ShouldSucceed()
        {
            PagingParameters pagingParameters = new(1, 10);
            Result<PagedList<GetCompanyDepartmentsResponse>> result =
                await GetCompanyDepartmentsQuery.Query(pagingParameters, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int departments = result.Value.Count;
            Assert.Equal(10, departments);
        }

        [Fact]
        public async Task Query_GetCompanyDepartmentsByNameQuery_ShouldSucceed()
        {
            const string deptName = "Pr";
            PagingParameters pagingParameters = new(1, 10);
            Result<PagedList<GetCompanyDepartmentsResponse>> result =
                await GetCompanyDepartmentsByNameQuery.Query(deptName, pagingParameters, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int departments = result.Value.Count;
            Assert.Equal(2, departments);
        }

        [Fact]
        public async Task Query_GetCompanyShiftsQuery_ShouldSucceed()
        {
            PagingParameters pagingParameters = new(1, 10);
            Result<PagedList<GetCompanyShiftsResponse>> result =
                await GetCompanyShiftsQuery.Query(pagingParameters, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int shifts = result.Value.Count;
            Assert.Equal(3, shifts);
        }
    }
}
