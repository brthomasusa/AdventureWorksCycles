using System.Data;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetPayHistoriesQuery
    {
        public async static Task<Result<List<PayHistory>>> Query
        (
            int businessEntityID,
            DapperContext ctx,
            ILogger<ReadRepositoryManager> logger
        )
        {
            try
            {
                const string sql = EmployeeQuerySql.GetPayHistories;

                var parameters = new DynamicParameters();
                parameters.Add("ID", businessEntityID, DbType.Int32);

                using var connection = ctx.CreateConnection();
                var result = await connection.QueryAsync<PayHistory>(sql, parameters);

                if (result is null)
                {
                    string errMsg = $"Unable to retrieve pay history for employee with ID: {businessEntityID}.";
                    logger.LogWarning($"Code Path: GetPayHistoriesQuery.Query - Message: {errMsg}");

                    return Result<List<PayHistory>>.Failure<List<PayHistory>>(
                        new Error("GetPayHistoriesQuery.Query", errMsg)
                    );
                }

                return result.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetPayHistoriesQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<List<PayHistory>>.Failure<List<PayHistory>>(
                    new Error("GetPayHistoriesQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}