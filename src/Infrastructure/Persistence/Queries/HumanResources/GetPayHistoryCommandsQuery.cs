using System.Data;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetPayHistoryCommandsQuery
    {
        public async static Task<Result<List<PayHistoryCommand>>> Query
        (
            int businessEntityID,
            DapperContext ctx,
            ILogger<ReadRepositoryManager> logger
        )
        {
            try
            {
                const string sql = EmployeeQuerySql.GetPayHistoryCommands;

                var parameters = new DynamicParameters();
                parameters.Add("ID", businessEntityID, DbType.Int32);

                using var connection = ctx.CreateConnection();
                var result = await connection.QueryAsync<PayHistoryCommand>(sql, parameters);

                if (result is null)
                {
                    string errMsg = $"Unable to retrieve pay history for employee with ID: {businessEntityID}.";
                    logger.LogWarning($"Code Path: GetPayHistoryCommandsQuery.Query - Message: {errMsg}");

                    return Result<List<PayHistoryCommand>>.Failure<List<PayHistoryCommand>>(
                        new Error("GetPayHistoryCommandsQuery.Query", errMsg)
                    );
                }

                return result.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetPayHistoryCommandsQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<List<PayHistoryCommand>>.Failure<List<PayHistoryCommand>>(
                    new Error("GetPayHistoryCommandsQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}