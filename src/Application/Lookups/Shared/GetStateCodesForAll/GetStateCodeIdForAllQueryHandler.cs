using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Lookups.Shared.GetStateCodesForAll
{
    public sealed class GetStateCodeIdForAllQueryHandler : IQueryHandler<GetStateCodeIdForAllRequest, List<StateCode>>
    {
        private readonly ILookupsRepositoryManager _repoMgr;

        public GetStateCodeIdForAllQueryHandler(ILookupsRepositoryManager repo)
            => _repoMgr = repo;

        public async Task<Result<List<StateCode>>> Handle
        (
            GetStateCodeIdForAllRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<List<StateCode>> result = await _repoMgr.SharedLookupsRepository.StateCodeIdAll();

                if (result.IsFailure)
                {
                    return Result<List<StateCode>>.Failure<List<StateCode>>(
                        new Error("GetStateCodeIdForAllQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<List<StateCode>>.Failure<List<StateCode>>(
                    new Error("GetStateCodeIdForAllQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}