using System.Data;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetDepartmentHistoriesCommandQuery
    {
        public async static Task<Result<List<DepartmentHistoryCommand>>> Query
        (
            int businessEntityID,
            DapperContext ctx,
            ILogger<ReadRepositoryManager> logger
        )
        {
            try
            {
                const string sql = EmployeeQuerySql.GetDepartmentHistoryCommands;

                var parameters = new DynamicParameters();
                parameters.Add("ID", businessEntityID, DbType.Int32);

                using var connection = ctx.CreateConnection();
                var result = await connection.QueryAsync<DepartmentHistoryCommand>(sql, parameters);

                if (result is null)
                {
                    string errMsg = $"Unable to retrieve department history for employee with ID: {businessEntityID}.";
                    logger.LogWarning($"Code Path: GetDepartmentHistoriesCommandQuery.Query - Message: {errMsg}");

                    return Result<List<DepartmentHistoryCommand>>.Failure<List<DepartmentHistoryCommand>>(
                        new Error("GetDepartmentHistoriesCommandQuery.Query", errMsg)
                    );
                }

                return result.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetDepartmentHistoriesCommandQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<List<DepartmentHistoryCommand>>.Failure<List<DepartmentHistoryCommand>>(
                    new Error("GetDepartmentHistoriesCommandQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}