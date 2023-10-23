using AWC.Application.Features.HumanResources.ViewEmployeeDetails;
using AWC.Application.Features.HumanResources.ViewEmployees;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTest.HumanResources.QueryHandlers
{
    [Collection("Database Test")]
    public class EmployeeQueryHandler_Tests : TestBase
    {
        private readonly IReadRepositoryManager _repository;

        public EmployeeQueryHandler_Tests()
            => _repository = new ReadRepositoryManager(_dapperCtx, new NullLogger<ReadRepositoryManager>());

        [Fact]
        public async Task Handle_GetEmployeeDetailsQueryHandler_ShouldSucceed()
        {
            GetEmployeeDetailsRequest request = new(EmployeeID: 2);
            GetEmployeeDetailsRequestQueryHandler handler = new(_repository);

            Result<EmployeeDetails> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_GetEmployeeDetailsQueryHandler_WithPayHistories_ShouldSucceed()
        {
            GetEmployeeDetailsRequest request = new(EmployeeID: 16);
            GetEmployeeDetailsRequestQueryHandler handler = new(_repository);

            Result<EmployeeDetails> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
            Assert.True(response.Value.PayHistories!.Count == 3);
        }

        [Fact]
        public async Task Handle_GetEmployeeDetailsQueryHandler_WithDepartmentHistories_ShouldSucceed()
        {
            GetEmployeeDetailsRequest request = new(EmployeeID: 16);
            GetEmployeeDetailsRequestQueryHandler handler = new(_repository);

            Result<EmployeeDetails> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
            Assert.True(response.Value.DepartmentHistories!.Count == 2);
        }

        [Fact]
        public async Task Handle_GetEmployeeCommandQueryHandler_ShouldSucceed()
        {
            GetEmployeeCommandRequest request = new(EmployeeID: 2);
            GetEmployeeCommandQueryHandler handler = new(_repository);

            Result<EmployeeGenericCommand> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_GetEmployeeCommandQueryHandler_WithPayHistoryCommands_ShouldSucceed()
        {
            GetEmployeeCommandRequest request = new(EmployeeID: 16);
            GetEmployeeCommandQueryHandler handler = new(_repository);

            Result<EmployeeGenericCommand> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
            Assert.True(response.Value.PayHistories!.Count == 3);
        }

        [Fact]
        public async Task Handle_GetEmployeeCommandQueryHandler_WithDepartmentHistoryCommands_ShouldSucceed()
        {
            GetEmployeeCommandRequest request = new(EmployeeID: 16);
            GetEmployeeCommandQueryHandler handler = new(_repository);

            Result<EmployeeGenericCommand> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
            Assert.True(response.Value.DepartmentHistories!.Count == 2);
        }

        [Fact]
        public async Task Handle_GetEmployeeDetailsQueryHandler_ShouldFail_WithInvalidID()
        {
            GetEmployeeDetailsRequest request = new(EmployeeID: 430);
            GetEmployeeDetailsRequestQueryHandler handler = new(_repository);

            Result<EmployeeDetails> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsFailure);
        }

        [Fact]
        public async Task Handle_GetEmployeeListItemsQueryHandler_ShouldSucceed()
        {
            StringSearchCriteria criteria = new("[LastName]", "Pr", "[LastName]", 1, 10, 0, 10);
            GetEmployeeListItemsRequest request = new(SearchCriteria: criteria);
            GetEmployeeListItemsQueryHandler handler = new(_repository);

            Result<PagedList<EmployeeListItem>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);

            int employees = response.Value.Count;
            Assert.Equal(2, employees);
        }

        [Fact]
        public async Task Handle_GetEmployeeListItemsQueryHandler_Search_ShouldSucceed()
        {
            StringSearchCriteria criteria = new("[LastName]", "Du", "[LastName]", 1, 10, 0, 10);
            GetEmployeeListItemsRequest request = new(SearchCriteria: criteria);
            GetEmployeeListItemsQueryHandler handler = new(_repository);

            Result<PagedList<EmployeeListItem>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);

            int employees = response.Value.Count;
            Assert.Equal(4, employees);
        }
    }
}