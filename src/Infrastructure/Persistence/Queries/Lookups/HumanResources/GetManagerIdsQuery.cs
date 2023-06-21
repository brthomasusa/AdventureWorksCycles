using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.Lookups.HumanResources
{
    public static class GetManagerIdsQuery
    {
        public async static Task<Result<List<ManagerId>>> Query
        (
            DapperContext ctx,
            ILogger<LookupsRepositoryManager> logger
        )
        {
            try
            {
                const string sql = LookupsQuerySql.GetManagerIds;

                using var connection = ctx.CreateConnection();
                var managerIds = await connection.QueryAsync<ManagerId>(sql);

                if (managerIds is null)
                {
                    return Result<List<ManagerId>>.Failure<List<ManagerId>>(
                        new Error("GetManagerIdsQuery.Query", "Oops! No manager ids found.")
                    );
                }

                return managerIds.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetManagerIdsQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<List<ManagerId>>.Failure<List<ManagerId>>(
                    new Error("GetManagerIdsQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}