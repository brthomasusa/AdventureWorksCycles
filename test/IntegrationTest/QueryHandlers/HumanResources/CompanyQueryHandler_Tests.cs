using AWC.Application.Features.HumanResources.ViewCompanyDepartments;
using AWC.Application.Features.HumanResources.ViewCompanyDetails;
using AWC.Application.Features.HumanResources.ViewCompanyShifts;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
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
            GetCompanyDetailsRequest request = new(CompanyID: 1);
            GetCompanyDetailsQueryHandler handler = new(_repository);

            Result<CompanyDetails> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_GetCompanyDetailByIdQueryHandler_ShouldFail_WithInvalidCompanyID()
        {
            GetCompanyDetailsRequest request = new(CompanyID: 2);
            GetCompanyDetailsQueryHandler handler = new(_repository);

            Result<CompanyDetails> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsFailure);
        }

        [Fact]
        public async Task Handle_GetCompanyCommandByIdQueryHandler_ShouldSucceed()
        {
            GetCompanyCommandRequest request = new(CompanyID: 1);
            GetCompanyCommandQueryHandler handler = new(_repository);

            Result<CompanyGenericCommand> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_GetCompanyCommandByIdQueryHandler_ShouldFail_WithInvalidCompanyID()
        {
            GetCompanyCommandRequest request = new(CompanyID: 2);
            GetCompanyCommandQueryHandler handler = new(_repository);

            Result<CompanyGenericCommand> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsFailure);
        }

        [Fact]
        public async Task Handle_GetCompanyDepartmentsQueryHandler_ShouldSucceed()
        {
            PagingParameters pagingParameters = new(1, 10);
            GetCompanyDepartmentsRequest request = new(PagingParameters: pagingParameters);
            GetCompanyDepartmentsQueryHandler handler = new(_repository);

            Result<PagedList<DepartmentDetails>> response = await handler.Handle(request, new CancellationToken());

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

            Result<PagedList<DepartmentDetails>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);

            int departments = response.Value.Count;
            Assert.Equal(2, departments);
        }

        [Fact]
        public async Task Handle_GetCompanyDepartmentsFilteredByNameQueryHandler_ShouldSucceed()
        {
            StringSearchCriteria criteria = new("[Name]", "Pr", "[Name]", 1, 10);
            GetCompanyDepartmentsFilteredRequest request = new(SearchCriteria: criteria);

            GetCompanyDepartmentsFilteredQueryHandler handler = new(_repository);

            Result<PagedList<DepartmentDetails>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);

            int departments = response.Value.Count;
            Assert.Equal(2, departments);
        }

        [Fact]
        public async Task Handle_GetCompanyDepartmentsFilteredByGroupNameQueryHandler_ShouldSucceed()
        {
            StringSearchCriteria criteria = new("GroupName", "Man", "[Name]", 1, 10);
            GetCompanyDepartmentsFilteredRequest request = new(SearchCriteria: criteria);

            GetCompanyDepartmentsFilteredQueryHandler handler = new(_repository);

            Result<PagedList<DepartmentDetails>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);

            int departments = response.Value.Count;
            Assert.Equal(4, departments);
        }

        [Fact]
        public async Task Handle_GetCompanyShiftsQueryHandler_ShouldSucceed()
        {
            PagingParameters pagingParameters = new(1, 10);
            GetCompanyShiftsRequest request = new(PagingParameters: pagingParameters);
            GetCompanyShiftsQueryHandler handler = new(_repository);

            Result<PagedList<ShiftDetails>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);

            int shifts = response.Value.Count;
            Assert.Equal(3, shifts);
        }
    }
}