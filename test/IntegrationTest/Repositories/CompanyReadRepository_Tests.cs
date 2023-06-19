using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Infrastructure.Persistence.Repositories.HumanResources;

using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.Repositories
{
    public class CompanyReadRepository_Tests : TestBase
    {
        [Fact]
        public async Task GetCompanyDetailsById_CompanyReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());
            Result<GetCompanyDetailByIdResponse> result = await readRepository.CompanyReadRepository.GetCompanyDetailsById(1);

            Assert.True(result.IsSuccess);
            Assert.Equal("Adventure-Works Cycles", result.Value.CompanyName);
        }

        [Fact]
        public async Task GetCompanyDetailsById_CompanyReadRepository_ShouldFail_WithInvalidEmployeeID()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<ReadRepositoryManager>();
            ReadRepositoryManager readRepository = new(_dapperCtx, logger);

            Result<GetCompanyDetailByIdResponse> result = await readRepository.CompanyReadRepository.GetCompanyDetailsById(111);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task GetCompanyCommandById_CompanyReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());

            Result<GetCompanyCommandByIdResponse> result = await readRepository.CompanyReadRepository.GetCompanyCommandById(1);

            Assert.True(result.IsSuccess);
            Assert.Equal("Adventure-Works Cycles", result.Value.CompanyName);
        }

        [Fact]
        public async Task GetCompanyCommandById_CompanyReadRepository_ShouldFail_WithInvalidEmployeeID()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<ReadRepositoryManager>();
            ReadRepositoryManager readRepository = new(_dapperCtx, logger);

            Result<GetCompanyCommandByIdResponse> result = await readRepository.CompanyReadRepository.GetCompanyCommandById(111);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task GetCompanyDepartments_CompanyReadRepository_ShouldSucceed()
        {
            ReadRepositoryManager readRepository = new(_dapperCtx, new NullLogger<ReadRepositoryManager>());
            PagingParameters pagingParameters = new(1, 10);

            Result<PagedList<GetCompanyDepartmentsResponse>> result =
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

            Result<PagedList<GetCompanyDepartmentsResponse>> result =
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

            Result<PagedList<GetCompanyShiftsResponse>> result =
                await readRepository.CompanyReadRepository.GetCompanyShifts(pagingParameters);

            Assert.True(result.IsSuccess);
            int shifts = result.Value.Count;
            Assert.Equal(3, shifts);
        }
    }
}