using AWC.Application.Features.HumanResources.Common;
using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Application.Features.HumanResources.ViewCompanyDepartments;
using AWC.Application.Features.HumanResources.ViewCompanyDetails;
using AWC.Application.Features.HumanResources.ViewCompanyShifts;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.Shared;
using AWC.Core.Interfaces.HumanResouces;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.UnitTest.Shared;
using AWC.UnitTest.Shared.Data;
using MapsterMapper;
using MockQueryable.Moq;
using Moq;
using Moq.EntityFrameworkCore;

namespace AWC.UnitTest.Application.Features.HumanResources.UpdateCompany
{
    public class UpdateCompanyCommandHandlerTest
    {
        [Fact]
        public async Task UpdateCompanyCommandHandler_Handle_ShouldReturn_Success()
        {
            // Arrange
            UpdateCompanyCommand command = CampanyTestData.GetUpdateCompanyCommandWithValidData();
            Result<Company> company = CampanyTestData.CompanyResultWithValidData();

            var companyrepositoryMock = new Mock<ICompanyWriteRepository>();
            companyrepositoryMock.Setup(r => r.Update(company.Value))
                                 .Returns(Task.FromResult(Result<int>.Success<int>(0)));

            var writeRepositoryMock = new Mock<IWriteRepositoryManager>();
            writeRepositoryMock.Setup(r => r.CompanyAggregateRepository)
                               .Returns(companyrepositoryMock.Object);

            UpdateCompanyCommandHandler handler = new(writeRepositoryMock.Object);

            // Act
            Result<int> result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.Equal(0, result.Value);
        }
    }
}