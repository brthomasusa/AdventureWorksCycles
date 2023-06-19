using AWC.Infrastructure.Persistence.Repositories;
using AWC.Infrastructure.Persistence.Repositories.Lookups;
using AWC.Shared.Queries.Lookups;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.Lookups
{
    public static class GetStateCodeIdAllQuery
    {
        public async static Task<Result<List<StateCode>>> Query
        (
            DapperContext ctx,
            ILogger<LookupsRepositoryManager> logger
        )
        {
            try
            {
                const string sql = LookupsQuerySql.GetStateCodeIdForAll;

                using var connection = ctx.CreateConnection();
                var stateCodes = await connection.QueryAsync<StateCode>(sql);

                if (stateCodes is null)
                {
                    return Result<List<StateCode>>.Failure<List<StateCode>>(
                        new Error("GetStateCodeIdAllQuery.Query", "Oops! No state province codes found.")
                    );
                }

                return stateCodes.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetStateCodeIdAllQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<List<StateCode>>.Failure<List<StateCode>>(
                    new Error("GetStateCodeIdAllQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}