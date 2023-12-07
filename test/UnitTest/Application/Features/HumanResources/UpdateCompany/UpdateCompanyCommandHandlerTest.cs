using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Core.Entities.HumanResources;
using AWC.UnitTest.Shared;
using AWC.UnitTest.Shared.Data;
using AWC.UnitTest.Shared.Data.MockRepositories;
using AWC.UnitTest.Shared.MockRepositories;
using Moq;
using MapsterMapper;

namespace AWC.UnitTest.Application.Features.HumanResources.UpdateCompany
{
    public class UpdateCompanyCommandHandlerTest
    {
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandlerTest()
            => _mapper = AddMapsterForUnitTests.GetMapper();

        [Fact]
        public async Task UpdateCompanyCommandHandler_Handle_ShouldReturn_Success()
        {
            // Arrange
            var repositoryManagerMock = MockWriteRepositoryManager.GetMock();
            UpdateCompanyCommandHandler handler = new(repositoryManagerMock.Object, _mapper);
            UpdateCompanyCommand command = CampanyTestData.GetUpdateCompanyCommandWithValidData();

            // Act
            Result<int> result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}
