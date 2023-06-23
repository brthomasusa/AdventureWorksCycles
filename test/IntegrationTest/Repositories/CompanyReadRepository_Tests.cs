using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;

using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.Repositories
{
    public class CompanyReadRepository_Tests : TestBase
    {
        [Fact]
        public async Task GetCompanyDetailsById_CompanyReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());
            Result<CompanyDetailsForDisplay> result = await readRepository.CompanyReadRepository.GetCompanyDetails(1);

            Assert.True(result.IsSuccess);
            Assert.Equal("Adventure-Works Cycles", result.Value.CompanyName);
        }

        [Fact]
        public async Task GetCompanyDetailsById_CompanyReadRepository_ShouldFail_WithInvalidEmployeeID()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<ReadRepositoryManager>();
            ReadRepositoryManager readRepository = new(_dapperCtx, logger);

            Result<CompanyDetailsForDisplay> result = await readRepository.CompanyReadRepository.GetCompanyDetails(111);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task GetCompanyCommandById_CompanyReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());

            Result<CompanyDetailsForEdit> result = await readRepository.CompanyReadRepository.GetCompanyCommand(1);

            Assert.True(result.IsSuccess);
            Assert.Equal("Adventure-Works Cycles", result.Value.CompanyName);
        }

        [Fact]
        public async Task GetCompanyCommandById_CompanyReadRepository_ShouldFail_WithInvalidEmployeeID()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<ReadRepositoryManager>();
            ReadRepositoryManager readRepository = new(_dapperCtx, logger);

            Result<CompanyDetailsForEdit> result = await readRepository.CompanyReadRepository.GetCompanyCommand(111);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task GetCompanyDepartments_CompanyReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());
            PagingParameters pagingParameters = new(1, 10);

            Result<PagedList<DepartmentDetails>> result =
                await readRepository.CompanyReadRepository.GetCompanyDepartments(pagingParameters);

            Assert.True(result.IsSuccess);
            int departments = result.Value.Count;
            Assert.Equal(10, departments);
        }

        [Fact]
        public async Task GetCompanyDepartmentsSearchByName_CompanyReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());
            const string deptName = "Pr";
            PagingParameters pagingParameters = new(1, 10);

            Result<PagedList<DepartmentDetails>> result =
                await readRepository.CompanyReadRepository.GetCompanyDepartmentsSearchByName(deptName, pagingParameters);

            Assert.True(result.IsSuccess);
            int departments = result.Value.Count;
            Assert.Equal(2, departments);
        }

        [Fact]
        public async Task GetCompanyShifts_CompanyReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());
            PagingParameters pagingParameters = new(1, 10);

            Result<PagedList<ShiftDetails>> result =
                await readRepository.CompanyReadRepository.GetCompanyShifts(pagingParameters);

            Assert.True(result.IsSuccess);
            int shifts = result.Value.Count;
            Assert.Equal(3, shifts);
        }
    }
}