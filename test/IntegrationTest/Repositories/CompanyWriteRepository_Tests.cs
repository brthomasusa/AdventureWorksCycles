using AWC.Core.HumanResources;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.Repositories
{
    public class CompanyWriteRepository_Tests : TestBase
    {
        [Fact]
        public async Task GetByIdAsync_CompnayAggregateRepo_ShouldSucceed()
        {
            WriteRepositoryManager writeRepository = new(_dbContext, new NullLogger<WriteRepositoryManager>());

            Result<Company> result = await writeRepository.CompanyAggregateRepository.GetByIdAsync(1);

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Departments.Any());
            Assert.True(result.Value.Shifts.Any());
        }

        [Fact]
        public async Task GetByIdAsync_CompnayAggregateRepo_InvalidCompanyID_ShouldFail()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<WriteRepositoryManager>();
            WriteRepositoryManager writeRepository = new(_dbContext, logger);

            Result<Company> result = await writeRepository.CompanyAggregateRepository.GetByIdAsync(11);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task Update_CompnayAggregateRepo_ValidData_ShouldSucceed()
        {
            WriteRepositoryManager writeRepository = new(_dbContext, new NullLogger<WriteRepositoryManager>());
            Company company = CompanyTestData.GetCompanyForUpdateWithValidData();

            Result<int> result = await writeRepository.CompanyAggregateRepository.Update(company);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Update_CompnayAggregateRepo_InvalidCompanyID_ShouldFail()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<WriteRepositoryManager>();
            WriteRepositoryManager writeRepository = new(_dbContext, logger);

            Company company = CompanyTestData.GetCompanyForUpdateWithInvalidCompanyID();

            Result<int> result = await writeRepository.CompanyAggregateRepository.Update(company);

            Assert.True(result.IsFailure);
        }
    }
}