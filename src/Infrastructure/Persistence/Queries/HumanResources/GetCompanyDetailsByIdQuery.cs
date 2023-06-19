using System.Data;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetCompanyDetailsByIdQuery
    {
        public async static Task<Result<GetCompanyDetailByIdResponse>> Query
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
                GetCompanyDetailByIdResponse detail = await connection.QueryFirstOrDefaultAsync<GetCompanyDetailByIdResponse>(sql, parameters);

                if (detail is null)
                {
                    string errMsg = $"Unable to retrieve company details for company with ID: {companyId}.";
                    logger.LogWarning($"Code Path: GetCompanyDetailsByIdQuery.Query - Message: {errMsg}");

                    return Result<GetCompanyDetailByIdResponse>.Failure<GetCompanyDetailByIdResponse>(
                        new Error("GetCompanyDetailsByIdQuery.Query", errMsg)
                    );
                }

                return detail;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetCompanyDetailsByIdQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<GetCompanyDetailByIdResponse>.Failure<GetCompanyDetailByIdResponse>(
                    new Error("GetCompanyDetailsByIdQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}
