using System.Data;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetCompanyDetailsQuery
    {
        public async static Task<Result<CompanyDetailsForDisplay>> Query
        (
            int companyId,
            DapperContext ctx,
            ILogger<ReadRepositoryManager> logger
        )
        {
            try
            {
                const string sql = CompanyQuerySql.GetCompanyDetailsById +
                " WHERE CompanyID = @ID";

                var parameters = new DynamicParameters();
                parameters.Add("ID", companyId, DbType.Int32);

                using var connection = ctx.CreateConnection();
                CompanyDetailsForDisplay detail = await connection.QueryFirstOrDefaultAsync<CompanyDetailsForDisplay>(sql, parameters);

                if (detail is null)
                {
                    string errMsg = $"Unable to retrieve company details for company with ID: {companyId}.";
                    logger.LogWarning($"Code Path: GetCompanyDetailsByIdQuery.Query - Message: {errMsg}");

                    return Result<CompanyDetailsForDisplay>.Failure<CompanyDetailsForDisplay>(
                        new Error("GetCompanyDetailsByIdQuery.Query", errMsg)
                    );
                }

                return detail;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetCompanyDetailsByIdQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<CompanyDetailsForDisplay>.Failure<CompanyDetailsForDisplay>(
                    new Error("GetCompanyDetailsByIdQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}
