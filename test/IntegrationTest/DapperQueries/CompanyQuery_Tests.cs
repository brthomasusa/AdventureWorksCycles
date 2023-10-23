using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTest.DapperQueries
{
    [Collection("Database Test")]
    public class CompanyQuery_Tests : TestBase
    {
        [Fact]
        public async Task Query_GetCompanyDetailsByIdQuery_ShouldSucceed()
        {
            Result<CompanyDetails> result = await GetCompanyDetailsQuery.Query(1, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Query_GetCompanyDetailsByIdQuery_ShouldFail_WhenPassedInvalidID()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<ReadRepositoryManager>();

            Result<CompanyDetails> result = await GetCompanyDetailsQuery.Query(100, _dapperCtx, logger);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task Query_GetCompanyCommandByIdQuery_ShouldSucceed()
        {
            Result<CompanyGenericCommand> result = await GetCompanyCommandQuery.Query(1, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Query_Query_GetCompanyCommandByIdQuery_ShouldFail_WhenPassedInvalidID()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<ReadRepositoryManager>();

            Result<CompanyGenericCommand> result = await GetCompanyCommandQuery.Query(100, _dapperCtx, logger);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task Query_GetCompanyDepartmentsQuery_ShouldSucceed()
        {
            PagingParameters pagingParameters = new(1, 10);
            Result<PagedList<DepartmentDetails>> result =
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
            Result<PagedList<DepartmentDetails>> result =
                await GetCompanyDepartmentsByNameQuery.Query(deptName, pagingParameters, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int departments = result.Value.Count;
            Assert.Equal(2, departments);
        }

        [Fact]
        public async Task Query_GetCompanyDepartmentsUnfilteredQuery_PageOne_ShouldSucceed()
        {
            StringSearchCriteria criteria = new(null, null, "[Name]", 1, 10, 0, 10);

            Result<PagedList<DepartmentDetails>> result =
                await GetCompanyDepartmentsFilteredQuery.Query(criteria, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int departments = result.Value.Count;
            Assert.Equal(10, departments);
        }

        [Fact]
        public async Task Query_GetCompanyDepartmentsUnfilteredQuery_PageTwo_ShouldSucceed()
        {
            StringSearchCriteria criteria = new(null, null, "[Name]", 1, 10, 10, 10);

            Result<PagedList<DepartmentDetails>> result =
                await GetCompanyDepartmentsFilteredQuery.Query(criteria, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int departments = result.Value.Count;
            Assert.Equal(6, departments);
        }

        [Fact]
        public async Task Query_GetCompanyDepartmentsFilteredByNameQuery_ShouldSucceed()
        {
            StringSearchCriteria criteria = new("[Name]", "Pr", "[Name]", 1, 10, 0, 10);

            Result<PagedList<DepartmentDetails>> result =
                await GetCompanyDepartmentsFilteredQuery.Query(criteria, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int departments = result.Value.Count;
            Assert.Equal(2, departments);
        }

        [Fact]
        public async Task Query_GetCompanyDepartmentsFilteredByGroupNameQuery_ShouldSucceed()
        {
            StringSearchCriteria criteria = new("[GroupName]", "Man", "[Name]", 1, 10, 0, 10);

            Result<PagedList<DepartmentDetails>> result =
                await GetCompanyDepartmentsFilteredQuery.Query(criteria, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int departments = result.Value.Count;
            Assert.Equal(4, departments);
        }

        [Fact]
        public async Task Query_GetCompanyDepartmentsNullCriteriaQuery_ShouldSucceed()
        {
            StringSearchCriteria criteria = new("[GroupName]", null, "[Name]", 1, 20, 0, 20);

            Result<PagedList<DepartmentDetails>> result =
                await GetCompanyDepartmentsFilteredQuery.Query(criteria, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int departments = result.Value.Count;
            Assert.Equal(16, departments);
        }

        [Fact]
        public async Task Query_GetCompanyDepartmentsNullFieldAndCriteriaQuery_ShouldFail()
        {
            StringSearchCriteria criteria = new("[GroupName]", null, "[Name]", 1, 20, 0, 20);

            Result<PagedList<DepartmentDetails>> result =
                await GetCompanyDepartmentsFilteredQuery.Query(criteria, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int departments = result.Value.Count;
            Assert.Equal(16, departments);
        }

        [Fact]
        public async Task Query_GetCompanyShiftsQuery_ShouldSucceed()
        {
            PagingParameters pagingParameters = new(1, 10);
            Result<PagedList<ShiftDetails>> result =
                await GetCompanyShiftsQuery.Query(pagingParameters, _dapperCtx, new NullLogger<ReadRepositoryManager>());

            Assert.True(result.IsSuccess);
            int shifts = result.Value.Count;
            Assert.Equal(3, shifts);
        }
    }
}
