using System.Data;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetEmployeeGenericCommandQuery
    {
        public async static Task<Result<EmployeeGenericCommand>> Query
        (
            int employeeId,
            DapperContext ctx,
            ILogger<ReadRepositoryManager> logger
        )
        {
            try
            {
                const string sql = EmployeeQuerySql.GetEmployeeCommand;

                var parameters = new DynamicParameters();
                parameters.Add("ID", employeeId, DbType.Int32);

                using var connection = ctx.CreateConnection();
                EmployeeGenericCommand cmd = await connection.QueryFirstOrDefaultAsync<EmployeeGenericCommand>(sql, parameters);

                if (cmd is null)
                {
                    string errMsg = $"Unable to retrieve employee command for employee with ID: {employeeId}.";
                    logger.LogWarning($"Code Path: GetEmployeeGenericCommandQuery.Query - Message: {errMsg}");

                    return Result<EmployeeGenericCommand>.Failure<EmployeeGenericCommand>(
                        new Error("GetEmployeeGenericCommandQuery.Query", errMsg)
                    );
                }

                return cmd;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetEmployeeGenericCommandQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<EmployeeGenericCommand>.Failure<EmployeeGenericCommand>(
                    new Error("GetEmployeeGenericCommandQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}
