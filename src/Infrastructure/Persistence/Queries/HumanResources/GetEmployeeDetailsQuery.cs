using System.Data;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetEmployeeDetailsQuery
    {
        public async static Task<Result<EmployeeDetails>> Query
        (
            int employeeId,
            DapperContext ctx,
            ILogger<ReadRepositoryManager> logger
        )
        {
            try
            {
                const string sql = EmployeeQuerySql.GetEmployeeDetails;

                var parameters = new DynamicParameters();
                parameters.Add("ID", employeeId, DbType.Int32);

                using var connection = ctx.CreateConnection();
                EmployeeDetails detail = await connection.QueryFirstOrDefaultAsync<EmployeeDetails>(sql, parameters);

                if (detail is null)
                {
                    string errMsg = $"Unable to retrieve employee details for employee with ID: {employeeId}.";
                    logger.LogWarning($"Code Path: GetEmployeeDetailsByIdWithAllInfoQuery.Query - Message: {errMsg}");

                    return Result<EmployeeDetails>.Failure<EmployeeDetails>(
                        new Error("GetEmployeeDetailsByIdWithAllInfoQuery.Query", errMsg)
                    );
                }

                return detail;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetEmployeeDetailsByIdWithAllInfoQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<EmployeeDetails>.Failure<EmployeeDetails>(
                    new Error("GetEmployeeDetailsByIdWithAllInfoQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}
