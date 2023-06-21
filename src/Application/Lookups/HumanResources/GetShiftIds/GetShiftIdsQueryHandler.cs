using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Lookups.HumanResources.GetShiftIds
{
    public sealed class GetShiftIdsQueryHandler : IQueryHandler<GetShiftIdsRequest, List<ShiftId>>
    {
        private readonly ILookupsRepositoryManager _repoMgr;

        public GetShiftIdsQueryHandler(ILookupsRepositoryManager repo)
            => _repoMgr = repo;

        public async Task<Result<List<ShiftId>>> Handle
        (
            GetShiftIdsRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<List<ShiftId>> result = await _repoMgr.HumanResourcesLookupsRepository.ShiftIds();

                if (result.IsFailure)
                {
                    return Result<List<ShiftId>>.Failure<List<ShiftId>>(
                        new Error("GetShiftIdsQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<List<ShiftId>>.Failure<List<ShiftId>>(
                    new Error("GetShiftIdsQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}