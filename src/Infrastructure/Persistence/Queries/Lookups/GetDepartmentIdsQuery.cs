using AWC.Infrastructure.Persistence.Repositories;
using AWC.Infrastructure.Persistence.Repositories.Lookups;
using AWC.Shared.Queries.Lookups;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.Lookups
{
    public static class GetDepartmentIdsQuery
    {
        public async static Task<Result<List<DepartmentId>>> Query
        (
            DapperContext ctx,
            ILogger<LookupsRepositoryManager> logger
        )
        {
            try
            {
                const string sql = LookupsQuerySql.GetDepartmentIds;

                using var connection = ctx.CreateConnection();
                var departmentIds = await connection.QueryAsync<DepartmentId>(sql);

                if (departmentIds is null)
                {
                    return Result<List<DepartmentId>>.Failure<List<DepartmentId>>(
                        new Error("GetDepartmentIdsQuery.Query", "Oops! No department ids found.")
                    );
                }

                return departmentIds.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetDepartmentIdsQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<List<DepartmentId>>.Failure<List<DepartmentId>>(
                    new Error("GetDepartmentIdsQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}