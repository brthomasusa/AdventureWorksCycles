using AWC.Application.Features.HumanResources.ViewCompanyDepartments;
using AWC.Application.Features.HumanResources.ViewCompanyDetails;
using AWC.Application.Features.HumanResources.ViewCompanyShifts;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.HumanResources.QueryHandlers
{
    public class CompanyQueryHandler_Tests : TestBase
    {
        private readonly IReadRepositoryManager _repository;

        public CompanyQueryHandler_Tests()
            => _repository = new ReadRepositoryManager(_dapperCtx, new NullLogger<ReadRepositoryManager>());

        [Fact]
        public async Task Handle_GetCompanyDetailByIdQueryHandler_ShouldSucceed()
        {
            GetCompanyDetailByIdRequest request = new(CompanyID: 1);
            GetCompanyDetailByIdQueryHandler handler = new(_repository);

            Result<GetCompanyDetailByIdResponse> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_GetCompanyDetailByIdQueryHandler_ShouldFail_WithInvalidCompanyID()
        {
            GetCompanyDetailByIdRequest request = new(CompanyID: 2);
            GetCompanyDetailByIdQueryHandler handler = new(_repository);

            Result<GetCompanyDetailByIdResponse> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsFailure);
        }

        [Fact]
        public async Task Handle_GetCompanyCommandByIdQueryHandler_ShouldSucceed()
        {
            GetCompanyCommandByIdRequest request = new(CompanyID: 1);
            GetCompanyCommandByIdQueryHandler handler = new(_repository);

            Result<GetCompanyCommandByIdResponse> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_GetCompanyCommandByIdQueryHandler_ShouldFail_WithInvalidCompanyID()
        {
            GetCompanyCommandByIdRequest request = new(CompanyID: 2);
            GetCompanyCommandByIdQueryHandler handler = new(_repository);

            Result<GetCompanyCommandByIdResponse> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsFailure);
        }

        [Fact]
        public async Task Handle_GetCompanyDepartmentsQueryHandler_ShouldSucceed()
        {
            PagingParameters pagingParameters = new(1, 10);
            GetCompanyDepartmentsRequest request = new(PagingParameters: pagingParameters);
            GetCompanyDepartmentsQueryHandler handler = new(_repository);

            Result<PagedList<GetCompanyDepartmentsResponse>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);

            int departments = response.Value.Count;
            Assert.Equal(10, departments);
        }

        [Fact]
        public async Task Handle_GetCompanyDepartmentsSearchByNameQueryHandler_ShouldSucceed()
        {
            PagingParameters pagingParameters = new(1, 10);
            GetCompanyDepartmentsSearchByNameRequest request = new(DepartmentName: "Pro", PagingParameters: pagingParameters);
            GetCompanyDepartmentsSearchByNameQueryHandler handler = new(_repository);

            Result<PagedList<GetCompanyDepartmentsResponse>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);

            int departments = response.Value.Count;
            Assert.Equal(2, departments);
        }

        [Fact]
        public async Task Handle_GetCompanyShiftsQueryHandler_ShouldSucceed()
        {
            PagingParameters pagingParameters = new(1, 10);
            GetCompanyShiftsRequest request = new(PagingParameters: pagingParameters);
            GetCompanyShiftsQueryHandler handler = new(_repository);

            Result<PagedList<GetCompanyShiftsResponse>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);

            int shifts = response.Value.Count;
            Assert.Equal(3, shifts);
        }
    }
}