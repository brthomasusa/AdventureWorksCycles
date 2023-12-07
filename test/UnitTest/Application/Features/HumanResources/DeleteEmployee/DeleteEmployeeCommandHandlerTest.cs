using AWC.Application.Features.HumanResources.DeleteEmployee;
using AWC.UnitTest.Shared;
using AWC.UnitTest.Shared.Data;
using AWC.UnitTest.Shared.MockRepositories;
using MapsterMapper;

namespace AWC.UnitTest.Application.Features.HumanResources.DeleteEmployee
{
    public class DeleteEmployeeCommandHandlerTest
    {
        private readonly IMapper _mapper;

        public DeleteEmployeeCommandHandlerTest()
            => _mapper = AddMapsterForUnitTests.GetMapper();

        [Fact]
        public async Task CreateEmployeeCommandHandler_Handle_ShouldReturn_Success()
        {
            // Arrange
            DeleteEmployeeCommand command = new(BusinessEntityID: 4);
            var repositoryManagerMock = MockWriteRepositoryManager.GetMock();
            DeleteEmployeeCommandHandler handler = new(repositoryManagerMock.Object);

            // Act
            Result<int> result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}