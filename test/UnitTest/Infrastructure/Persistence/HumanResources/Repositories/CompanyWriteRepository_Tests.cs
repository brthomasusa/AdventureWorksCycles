using AWC.Core.Interfaces.HumanResouces;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.UnitTest.Shared.Data;
using Moq;

using CompanyDomainModel = AWC.Core.Entities.HumanResources.Company;

namespace AWC.UnitTest.Infrastructure.UnitTests.Persistence.HumanResources.Repositories
{
    public class CompanyWriteRepository_Tests
    {
        [Fact(Skip = "Faulty implementation")]
        public async Task WriteRepositoryManager_CompanyAggregateRepository_GetByIdAsync_Should_Succeed()
        {
            // Arrange
            var companyrepositoryMock = new Mock<ICompanyWriteRepository>();
            companyrepositoryMock.Setup(r => r.GetByIdAsync(1, true))
                                 .Returns(Task.FromResult(CampanyTestData.CompanyResultWithValidData()));

            var writeRepositoryMock = new Mock<IWriteRepositoryManager>();
            writeRepositoryMock.Setup(r => r.CompanyAggregateRepository)
                               .Returns(companyrepositoryMock.Object);

            // Act
            Result<CompanyDomainModel> result = await writeRepositoryMock.Object.CompanyAggregateRepository.GetByIdAsync(1, true);

            // Assert
            Assert.True(result.IsSuccess);
        }




    }
}