using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.Lookups;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Lookups.GetStateCodesForUSA
{
    public sealed class GetStateCodeIdForUSAQueryHandler : IQueryHandler<GetStateCodeIdForUSARequest, List<StateCode>>
    {
        private readonly ILookupsRepositoryManager _repo;

        public GetStateCodeIdForUSAQueryHandler(ILookupsRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<List<StateCode>>> Handle
        (
            GetStateCodeIdForUSARequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<List<StateCode>> result = await _repo.LookupsRepository.StateCodeIdUSA();

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