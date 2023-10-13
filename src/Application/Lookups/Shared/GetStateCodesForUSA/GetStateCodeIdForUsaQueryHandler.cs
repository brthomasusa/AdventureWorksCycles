using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Lookups.Shared.GetStateCodesForUSA
{
    public sealed class GetStateCodeIdForUsaQueryHandler : IQueryHandler<GetStateCodeIdForUsaRequest, List<StateCode>>
    {
        private readonly ILookupsRepositoryManager _repoMgr;

        public GetStateCodeIdForUsaQueryHandler(ILookupsRepositoryManager repo)
            => _repoMgr = repo;

        public async Task<Result<List<StateCode>>> Handle
        (
            GetStateCodeIdForUsaRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<List<StateCode>> result = await _repoMgr.SharedLookupsRepository.StateCodeIdUSA();

                if (result.IsFailure)
                {
                    return Result<List<StateCode>>.Failure<List<StateCode>>(
                        new Error("GetStateCodeIdForUSAQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<List<StateCode>>.Failure<List<StateCode>>(
                    new Error("GetStateCodeIdForUSAQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}