using AWC.Application.Lookups.GetDepartmentIds;
using AWC.Application.Lookups.GetShiftIds;
using AWC.Application.Lookups.GetStateCodesForAll;
using AWC.Application.Lookups.GetStateCodesForUSA;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.Lookups;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.QueryHandlers.HumanResources
{
    public class LookupsQueryHandler_Tests : TestBase
    {
        private readonly ILookupsRepositoryManager _repository;

        public LookupsQueryHandler_Tests()
            => _repository = new LookupsRepositoryManager(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

        [Fact]
        public async Task Handle_GetStateCodeIdForUSAQueryHandler_ShouldSucceed()
        {
            GetStateCodeIdForUSARequest request = new();
            GetStateCodeIdForUSAQueryHandler handler = new(_repository);

            Result<List<StateCode>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_GetStateCodeIdForAllQueryHandler_ShouldSucceed()
        {
            GetStateCodeIdForAllRequest request = new();
            GetStateCodeIdForAllQueryHandler handler = new(_repository);

            Result<List<StateCode>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_GetDepartmentIdsQueryHandler_ShouldSucceed()
        {
            GetDepartmentIdsRequest request = new();
            GetDepartmentIdsQueryHandler handler = new(_repository);

            Result<List<DepartmentId>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task Handle_GetShiftIdsQueryHandler_ShouldSucceed()
        {
            GetShiftIdsRequest request = new();
            GetShiftIdsQueryHandler handler = new(_repository);

            Result<List<ShiftId>> response = await handler.Handle(request, new CancellationToken());

            Assert.True(response.IsSuccess);
        }
    }
}