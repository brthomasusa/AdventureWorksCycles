using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.Lookups.Shared
{
    public static class GetCountryCodesQuery
    {
        public async static Task<Result<List<CountryCode>>> Query
        (
            DapperContext ctx,
            ILogger<LookupsRepositoryManager> logger
        )
        {
            try
            {
                const string sql = LookupsQuerySql.GetCountryCodes;

                using var connection = ctx.CreateConnection();
                var countryCodes = await connection.QueryAsync<CountryCode>(sql);

                if (countryCodes is null)
                {
                    return Result<List<CountryCode>>.Failure<List<CountryCode>>(
                        new Error("GetCountryCodesQuery", "Oops! No country codes found.")
                    );
                }

                return countryCodes.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GGetCountryCodesQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<List<CountryCode>>.Failure<List<CountryCode>>(
                    new Error("GetCountryCodesQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}