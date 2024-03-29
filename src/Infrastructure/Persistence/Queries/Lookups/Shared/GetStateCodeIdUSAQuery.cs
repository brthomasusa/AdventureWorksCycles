using AWC.Infrastructure.Persistence.Repositories;
using AWC.Infrastructure.Persistence.Repositories.Lookups;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.Lookups
{
    public static class GetStateCodeIdUSAQuery
    {
        public async static Task<Result<List<StateCode>>> Query
        (
            DapperContext ctx,
            ILogger<LookupsRepositoryManager> logger
        )
        {
            try
            {
                const string sql = LookupsQuerySql.GetStateCodeIdForUSA;

                using var connection = ctx.CreateConnection();
                var stateCodes = await connection.QueryAsync<StateCode>(sql);

                if (stateCodes is null)
                {
                    return Result<List<StateCode>>.Failure<List<StateCode>>(
                        new Error("GetStateCodeIdForUSAQuery.Query", "Oops! No U.S. state province codes found.")
                    );
                }

                return stateCodes.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetStateCodeIdForUSAQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<List<StateCode>>.Failure<List<StateCode>>(
                    new Error("GetStateCodeIdForUSAQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}