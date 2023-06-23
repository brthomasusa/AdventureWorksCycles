using System.Data;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Infrastructure.Persistence.Repositories.HumanResources;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetCompanyDepartmentsByNameQuery
    {
        private static int Offset(int page, int pageSize) => (page - 1) * pageSize;

        public async static Task<Result<PagedList<DepartmentDetails>>> Query
        (
            string departmentName,
            PagingParameters pagingParameters,
            DapperContext ctx,
            ILogger<ReadRepositoryManager> logger
        )
        {
            try
            {
                const string sql = CompanyQuerySql.GetCompanyDepartmentsByName +
                    " WHERE [Name] LIKE CONCAT('%',@DeptName,'%')" +
                    " ORDER BY [Name]" +
                    " OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                var parameters = new DynamicParameters();
                parameters.Add("DeptName", departmentName, DbType.String);
                parameters.Add("Offset", Offset(pagingParameters.PageNumber, pagingParameters.PageSize), DbType.Int32);
                parameters.Add("PageSize", pagingParameters.PageSize, DbType.Int32);

                const string countSql = "SELECT COUNT(*) FROM HumanResources.Department WHERE [Name] LIKE CONCAT('%',@DeptName,'%')";

                using var connection = ctx.CreateConnection();

                var items = await connection.QueryAsync<DepartmentDetails>(sql, parameters);
                int count = connection.ExecuteScalar<int>(countSql, parameters);

                var pagedList = PagedList<DepartmentDetails>.CreatePagedList(
                        items.ToList(), count, pagingParameters.PageNumber, pagingParameters.PageSize
                    );

                return pagedList;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetCompanyDepartmentsQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");

                return Result<PagedList<DepartmentDetails>>.Failure<PagedList<DepartmentDetails>>(
                    new Error("GetCompanyDepartmentsQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}