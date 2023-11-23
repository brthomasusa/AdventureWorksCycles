using AWC.Core.Entities.HumanResources;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.SharedKernel.Utilities;
using MapsterMapper;

namespace AWC.IntegrationTests.Repositories
{
    [Collection("Database Test")]
    public class CompanyWriteRepository_Tests : TestBase
    {
        private readonly IMapper _mapper = AWC.IntegrationTest.AddMapsterForUnitTests.GetMapper();

        [Fact]
        public async Task GetByIdAsync_CompnayAggregateRepo_ShouldSucceed()
        {
            WriteRepositoryManager writeRepository = new(_dbContext, new NullLogger<WriteRepositoryManager>(), _mapper);

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
            WriteRepositoryManager writeRepository = new(_dbContext, logger, _mapper);

            Result<Company> result = await writeRepository.CompanyAggregateRepository.GetByIdAsync(11);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task Update_CompnayAggregateRepo_ValidData_ShouldSucceed()
        {
            WriteRepositoryManager writeRepository = new(_dbContext, new NullLogger<WriteRepositoryManager>(), _mapper);
            Company company = CompanyTestData.GetCompanyForUpdateWithValidData();

            Result<int> result = await writeRepository.CompanyAggregateRepository.Update(company);

            Assert.True(result.IsSuccess);

            Result<Company> searchResult = await writeRepository.CompanyAggregateRepository.GetByIdAsync(company.Id.Value);
            Assert.True(searchResult.IsSuccess);
            Assert.Equal(company.CompanyName, searchResult.Value.CompanyName);
        }
    }
}