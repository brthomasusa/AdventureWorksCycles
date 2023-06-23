using System.Data;
using AWC.Infrastructure.Persistence;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Infrastructure.Persistence.Repositories.HumanResources;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class GetCompanyShiftsQuery
    {
        private static int Offset(int page, int pageSize) => (page - 1) * pageSize;

        public async static Task<Result<PagedList<ShiftDetails>>> Query
        (
            PagingParameters pagingParameters,
            DapperContext ctx,
            ILogger<ReadRepositoryManager> logger
        )
        {
            try
            {
                const string sql = CompanyQuerySql.GetCompanyShifts +
                    " OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                var parameters = new DynamicParameters();
                parameters.Add("Offset", Offset(pagingParameters.PageNumber, pagingParameters.PageSize), DbType.Int32);
                parameters.Add("PageSize", pagingParameters.PageSize, DbType.Int32);

                using var connection = ctx.CreateConnection();

                var items = await connection.QueryAsync<ShiftDetails>(sql, parameters);
                int count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM HumanResources.Shift");

                var pagedList = PagedList<ShiftDetails>.CreatePagedList(
                        items.ToList(), count, pagingParameters.PageNumber, pagingParameters.PageSize
                    );

                return pagedList;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetCompanyShiftsQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");

                return Result<PagedList<ShiftDetails>>.Failure<PagedList<ShiftDetails>>(
                    new Error("GetCompanyShiftsQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}