using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.UnitTest.Shared;
using AWC.UnitTest.Shared.Data;
using AWC.UnitTest.Shared.MockRepositories;
using MapsterMapper;

namespace AWC.UnitTest.Application.Features.HumanResources.UpdateEmployee
{
    public class UpdateEmployeeCommandHandlerTest
    {
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandlerTest()
            => _mapper = AddMapsterForUnitTests.GetMapper();

        [Fact]
        public async Task UpdateEmployeeCommandHandler_Handle_ShouldReturn_Success()
        {
            // Arrange
            var repositoryManagerMock = MockWriteRepositoryManager.GetMock();
            UpdateEmployeeCommandHandler handler = new(repositoryManagerMock.Object, _mapper);
            UpdateEmployeeCommand command = EmployeeTestData.GetUpdateEmployeeCommand_ValidData();

            // Act
            Result<int> result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
        }


    }
}