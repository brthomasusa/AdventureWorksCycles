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
    public static class GetEmployeeListItemsQuery
    {
        public async static Task<Result<PagedList<EmployeeListItem>>> Query
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
                sb.Append(EmployeeQuerySql.GetEmployeeListItems);

                if (!string.IsNullOrEmpty(searchCriteria.SearchField) && !string.IsNullOrEmpty(searchCriteria.SearchCriteria))
                {
                    sb.Append(" WHERE ")
                      .Append(searchCriteria.SearchField)
                      .Append(" LIKE CONCAT('%',@Criteria,'%') ");
                }

                if (!string.IsNullOrEmpty(searchCriteria.OrderBy))
                    sb.Append(" ORDER BY ").Append(searchCriteria.OrderBy);
                else
                    sb.Append(" ORDER BY LastName, FirstName, MiddleName");

                sb.Append(" OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY");

                parameters.Add("Criteria", searchCriteria.SearchCriteria, DbType.String);
                parameters.Add("Offset", searchCriteria.Skip, DbType.Int32);
                parameters.Add("PageSize", searchCriteria.Take, DbType.Int32);

                string countSql = !string.IsNullOrEmpty(searchCriteria.SearchCriteria) &&
                                  !string.IsNullOrEmpty(searchCriteria.SearchField) ?
                    $"{EmployeeQuerySql.GetEmployeeListItemsCount} WHERE {searchCriteria.SearchField} LIKE CONCAT('%',@Criteria,'%')" :
                    EmployeeQuerySql.GetEmployeeListItemsCount;

                using var connection = ctx.CreateConnection();

                var items = await connection.QueryAsync<EmployeeListItem>(sb.ToString(), parameters);
                int count = connection.ExecuteScalar<int>(countSql, parameters);

                var pagedList = PagedList<EmployeeListItem>.CreatePagedList(
                        items.ToList(), count, searchCriteria.PageNumber, searchCriteria.PageSize
                    );

                return pagedList;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetEmployeeListItemsQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");

                return Result<PagedList<EmployeeListItem>>.Failure<PagedList<EmployeeListItem>>(
                    new Error("GetEmployeeListItemsQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}
