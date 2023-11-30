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
using AWC.UnitTest.Shared.MockRepositories;

namespace AWC.UnitTest.Application.Features.HumanResources.UpdateCompany
{
    public class UpdateCompanyCommandHandlerTest
    {
        [Fact]
        public async Task UpdateCompanyCommandHandler_Handle_ShouldReturn_Success()
        {
            // Arrange
            var repositoryManagerMock = MockWriteRepositoryManager.GetMock();
            UpdateCompanyCommandHandler handler = new(repositoryManagerMock.Object);
            UpdateCompanyCommand command = CampanyTestData.GetUpdateCompanyCommandWithValidData();

            // Act
            Result<int> result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}