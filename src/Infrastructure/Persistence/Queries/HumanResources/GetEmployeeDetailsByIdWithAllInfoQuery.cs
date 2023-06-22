using System.Data;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetEmployeeDetailsByIdWithAllInfoQuery
    {
        public async static Task<Result<EmployeeDetailsForDisplay>> Query
        (
            int employeeId,
            DapperContext ctx,
            ILogger<ReadRepositoryManager> logger
        )
        {
            try
            {
                const string sql = "SELECT * FROM HumanResources.udfGetEmployeeDetails(@ID)";
                var parameters = new DynamicParameters();
                parameters.Add("ID", employeeId, DbType.Int32);

                using var connection = ctx.CreateConnection();
                EmployeeDetailsForDisplay detail = await connection.QueryFirstOrDefaultAsync<EmployeeDetailsForDisplay>(sql, parameters);

                if (detail is null)
                {
                    string errMsg = $"Unable to retrieve employee details for employee with ID: {employeeId}.";
                    logger.LogWarning($"Code Path: GetEmployeeDetailsByIdWithAllInfoQuery.Query - Message: {errMsg}");

                    return Result<EmployeeDetailsForDisplay>.Failure<EmployeeDetailsForDisplay>(
                        new Error("GetEmployeeDetailsByIdWithAllInfoQuery.Query", errMsg)
                    );
                }

                return detail;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetEmployeeDetailsByIdWithAllInfoQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<EmployeeDetailsForDisplay>.Failure<EmployeeDetailsForDisplay>(
                    new Error("GetEmployeeDetailsByIdWithAllInfoQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}
