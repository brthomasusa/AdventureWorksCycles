using System.Data;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetCompanyCommandQuery
    {
        public async static Task<Result<CompanyGenericCommand>> Query
        (
            int companyId,
            DapperContext ctx,
            ILogger<ReadRepositoryManager> logger
        )
        {
            try
            {
                const string sql = CompanyQuerySql.GetCompanyCommandById +
                " WHERE CompanyID = @ID";

                var parameters = new DynamicParameters();
                parameters.Add("ID", companyId, DbType.Int32);

                using var connection = ctx.CreateConnection();
                CompanyGenericCommand detail = await connection.QueryFirstOrDefaultAsync<CompanyGenericCommand>(sql, parameters);

                if (detail is null)
                {
                    string errMsg = $"Unable to retrieve company command for company with ID: {companyId}.";
                    logger.LogWarning($"Code Path: GetCompanyCommandsQuery.Query - Message: {errMsg}");

                    return Result<CompanyGenericCommand>.Failure<CompanyGenericCommand>(
                        new Error("GetCompanyCommandByIdQuery.Query", errMsg)
                    );
                }

                return detail;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetCompanyCommandQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<CompanyGenericCommand>.Failure<CompanyGenericCommand>(
                    new Error("GetCompanyCommandQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}