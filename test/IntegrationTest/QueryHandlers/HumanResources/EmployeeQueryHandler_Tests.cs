using AWC.Application.Features.HumanResources.ViewEmployeeDetails;
using AWC.Application.Features.HumanResources.ViewEmployees;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.HumanResources.QueryHandlers
{
    public class EmployeeQueryHandler_Tests : TestBase
    {
        private readonly IReadRepositoryManager _repository;

        public EmployeeQueryHandler_Tests()
            => _repository = new ReadRepositoryManager(_dapperCtx, new NullLogger<ReadRepositoryManager>());

        [Fact]
        public async Task Handle_GetEmployeeDetailsByIdWithAllInfoQueryHandler_ShouldSucceed()
        {
            GetEmployeeDetailsRequest request = new(EmployeeID: 2);
            GetEmployeeDetailsRequestQueryHandler handler = new(_repository);

            Result<EmployeeDetailsResponse> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_GetEmployeeDetailsByIdWithAllInfoQueryHandler_ShouldFail_WithInvalidID()
        {
            GetEmployeeDetailsRequest request = new(EmployeeID: 430);
            GetEmployeeDetailsRequestQueryHandler handler = new(_repository);

            Result<EmployeeDetailsResponse> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsFailure);
        }

        [Fact]
        public async Task Handle_GetEmployeeListItemsQueryHandler_ShouldSucceed()
        {
            PagingParameters pagingParameters = new(1, 10);
            GetEmployeeListItemsRequest request = new(LastName: "Bradley", PagingParameters: pagingParameters);
            GetEmployeeListItemsQueryHandler handler = new(_repository);

            Result<PagedList<EmployeeListItemResponse>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);

            int employees = response.Value.Count;
            Assert.Equal(1, employees);
        }

        [Fact]
        public async Task Handle_GetEmployeeListItemsQueryHandler_Search_ShouldSucceed()
        {
            PagingParameters pagingParameters = new(1, 10);
            GetEmployeeListItemsRequest request = new(LastName: "A", PagingParameters: pagingParameters);
            GetEmployeeListItemsQueryHandler handler = new(_repository);

            Result<PagedList<EmployeeListItemResponse>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);

            int employees = response.Value.Count;
            Assert.Equal(10, employees);
        }
    }
}