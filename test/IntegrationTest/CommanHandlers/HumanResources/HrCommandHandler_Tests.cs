using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Features.HumanResources.DeleteEmployee;
using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.HumanResources.CommandHandlers
{
    [Collection("Database Test")]
    public class HrCommandHandler_Tests : TestBase
    {
        private readonly IWriteRepositoryManager _writeRepository;

        public HrCommandHandler_Tests()
            => _writeRepository = new WriteRepositoryManager(_dbContext, new NullLogger<WriteRepositoryManager>());

        [Fact]
        public async Task Handle_CreateEmployeeCommandHandler_ShouldSucceed()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            CreateEmployeeCommandHandler handler = new(_writeRepository);

            Result<int> result = await handler.Handle(command, new CancellationToken());

            Assert.True(result.IsSuccess);
            Assert.True(result.Value > 0);
        }

        [Fact]
        public async Task Handle_UpdateEmployeeCommandHandler_ShouldSucceed()
        {
            UpdateEmployeeCommand command = EmployeeTestData.GetUpdateEmployeeCommand_ValidData();
            UpdateEmployeeCommandHandler handler = new(_writeRepository);

            Result<int> result = await handler.Handle(command, new CancellationToken());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Handle_DeleteEmployeeCommandHandler_ShouldSucceed()
        {
            DeleteEmployeeCommand command = new(BusinessEntityID: 4);
            DeleteEmployeeCommandHandler handler = new(_writeRepository);

            Result<int> result = await handler.Handle(command, new CancellationToken());

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task Handle_UpdatCompanyCommandHandler_ShouldSucceed()
        {
            UpdateCompanyCommand command = CompanyTestData.GetUpdateCompanyCommandWithValidData();
            UpdateCompanyCommandHandler handler = new(_writeRepository);

            Result<int> result = await handler.Handle(command, new CancellationToken());

            Assert.True(result.IsSuccess);
        }
    }
}