using System.Data;
using System.Text;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetCompanyDepartmentsFilteredQuery
    {
        public async static Task<Result<PagedList<DepartmentDetails>>> Query
        (
            StringSearchCriteria searchCriteria,
            DapperContext ctx,
            ILogger<ReadRepositoryManager> logger
        )
        {
            try
            {
                var parameters = new DynamicParameters();

                StringBuilder sb = new();
                sb.Append(CompanyQuerySql.GetCompanyDepartmentsFiltered);

                if (!string.IsNullOrEmpty(searchCriteria.SearchField) && !string.IsNullOrEmpty(searchCriteria.SearchCriteria))
                {
                    sb.Append(" WHERE ")
                      .Append(searchCriteria.SearchField)
                      .Append(" LIKE CONCAT('%',@Criteria,'%') ");

                    parameters.Add("Criteria", searchCriteria.SearchCriteria, DbType.String);
                }

                if (!string.IsNullOrEmpty(searchCriteria.OrderBy))
                    sb.Append(" ORDER BY ").Append(searchCriteria.OrderBy);
                else
                    sb.Append(" ORDER BY [Name]");

                sb.Append(" OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY");

                parameters.Add("Offset", searchCriteria.Skip, DbType.Int32);
                parameters.Add("PageSize", searchCriteria.Take, DbType.Int32);

                string countSql = !string.IsNullOrEmpty(searchCriteria.SearchCriteria) ?
                    $"SELECT COUNT(*) FROM HumanResources.Department WHERE {searchCriteria.SearchField} LIKE CONCAT('%',@Criteria,'%')" :
                    "SELECT COUNT(*) FROM HumanResources.Department";

                using var connection = ctx.CreateConnection();

                var items = await connection.QueryAsync<DepartmentDetails>(sb.ToString(), parameters);
                int count = connection.ExecuteScalar<int>(countSql, parameters);

                var pagedList = PagedList<DepartmentDetails>.CreatePagedList(
                        items.ToList(), count, searchCriteria.PageNumber, searchCriteria.PageSize
                    );

                return pagedList;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetCompanyDepartmentsFilteredQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");

                return Result<PagedList<DepartmentDetails>>.Failure<PagedList<DepartmentDetails>>(
                    new Error("GetCompanyDepartmentsFilteredQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}
