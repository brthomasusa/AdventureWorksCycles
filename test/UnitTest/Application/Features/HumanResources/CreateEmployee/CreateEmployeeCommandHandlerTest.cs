using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.UnitTest.Shared;
using AWC.UnitTest.Shared.Data;
using AWC.UnitTest.Shared.MockRepositories;
using MapsterMapper;

namespace AWC.UnitTest.Application.Features.HumanResources.CreateEmployee
{
    public class CreateEmployeeCommandHandlerTest
    {
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandlerTest()
            => _mapper = AddMapsterForUnitTests.GetMapper();

        [Fact]
        public async Task CreateEmployeeCommandHandler_Handle_ShouldReturn_Success()
        {
            // Arrange
            var repositoryManagerMock = MockWriteRepositoryManager.GetMock();
            CreateEmployeeCommandHandler handler = new(repositoryManagerMock.Object, _mapper);
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();

            // Act
            Result<int> result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}