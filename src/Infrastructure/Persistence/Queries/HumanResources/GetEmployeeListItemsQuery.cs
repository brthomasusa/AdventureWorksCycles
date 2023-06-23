using System.Data;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetEmployeeListItemsQuery
    {
        private static int Offset(int page, int pageSize) => (page - 1) * pageSize;

        public async static Task<Result<PagedList<EmployeeListItem>>> Query
        (
            string lastName,
            PagingParameters pagingParameters,
            DapperContext ctx,
            ILogger<ReadRepositoryManager> logger
        )
        {
            try
            {
                const string sql = EmployeeQuerySql.GetEmployeeListItems +
                    " WHERE edh.EndDate IS NULL AND p.LastName LIKE CONCAT('%',@LName,'%')" +
                    " ORDER BY p.LastName, p.FirstName, p.MiddleName" +
                    " OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                var parameters = new DynamicParameters();
                parameters.Add("LName", lastName, DbType.String);
                parameters.Add("Offset", Offset(pagingParameters.PageNumber, pagingParameters.PageSize), DbType.Int32);
                parameters.Add("PageSize", pagingParameters.PageSize, DbType.Int32);

                const string countSql = EmployeeQuerySql.GetEmployeeListItemsCount;

                using var connection = ctx.CreateConnection();

                var items = await connection.QueryAsync<EmployeeListItem>(sql, parameters);
                int count = connection.ExecuteScalar<int>(countSql, parameters);

                var pagedList = PagedList<EmployeeListItem>.CreatePagedList(
                        items.ToList(), count, pagingParameters.PageNumber, pagingParameters.PageSize
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