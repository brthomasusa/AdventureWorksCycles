using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Core.Entities.HumanResources;
using AWC.UnitTest.Shared.Data;
using AWC.UnitTest.Shared.Data.MockRepositories;
using AWC.UnitTest.Shared.MockRepositories;
using Moq;

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