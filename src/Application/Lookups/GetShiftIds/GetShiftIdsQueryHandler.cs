using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.Lookups;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Lookups.GetShiftIds
{
    public sealed class GetShiftIdsQueryHandler : IQueryHandler<GetShiftIdsRequest, List<ShiftId>>
    {
        private readonly ILookupsRepositoryManager _repo;

        public GetShiftIdsQueryHandler(ILookupsRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<List<ShiftId>>> Handle
        (
            GetShiftIdsRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<List<ShiftId>> result = await _repo.LookupsRepository.ShiftIds();

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