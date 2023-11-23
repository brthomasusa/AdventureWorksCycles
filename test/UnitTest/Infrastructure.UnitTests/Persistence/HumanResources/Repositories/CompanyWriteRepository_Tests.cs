using Microsoft.Extensions.Logging;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Interfaces.HumanResouces;
using AWC.Infrastructure.Persistence;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Infrastructure.Persistence.Repositories.HumanResources;
using AWC.SharedKernel.Utilities;
using AWC.UnitTest.Shared.MockDbContext;
using MapsterMapper;

namespace AWC.UnitTest.Infrastructure.UnitTests.Persistence.HumanResources.Repositories
{
    public class CompanyWriteRepository_Tests
    {
        private ICompanyWriteRepository _companyRepository;

        public CompanyWriteRepository_Tests()
            => _companyRepository = CompanyRepositoryMock.GetMock();

        [Fact]
        public async Task GetByIdAsync_CompnayAggregateRepo_ShouldSucceed()
        {
            // Arrange

            // Act
            Result<Company> result = await _companyRepository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result.Value);
        }
    }
}