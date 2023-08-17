using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Lookups.Shared.GetCountryCodes
{
    public sealed class GetCountryCodesQueryHandler : IQueryHandler<GetCountryCodesRequest, List<CountryCode>>
    {
        private readonly ILookupsRepositoryManager _repoMgr;

        public GetCountryCodesQueryHandler(ILookupsRepositoryManager repo)
            => _repoMgr = repo;

        public async Task<Result<List<CountryCode>>> Handle
        (
            GetCountryCodesRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<List<CountryCode>> result = await _repoMgr.SharedLookupsRepository.CountryRegionCode();

                if (result.IsFailure)
                {
                    return Result<List<CountryCode>>.Failure<List<CountryCode>>(
                        new Error("GetCountryCodesQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<List<CountryCode>>.Failure<List<CountryCode>>(
                    new Error("GetCountryCodesQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}