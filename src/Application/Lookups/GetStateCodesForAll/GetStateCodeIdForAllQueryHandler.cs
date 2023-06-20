using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.Lookups;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Lookups.GetStateCodesForAll
{
    public sealed class GetStateCodeIdForAllQueryHandler : IQueryHandler<GetStateCodeIdForAllRequest, List<StateCode>>
    {
        private readonly ILookupsRepositoryManager _repo;

        public GetStateCodeIdForAllQueryHandler(ILookupsRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<List<StateCode>>> Handle
        (
            GetStateCodeIdForAllRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<List<StateCode>> result = await _repo.LookupsRepository.StateCodeIdAll();

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