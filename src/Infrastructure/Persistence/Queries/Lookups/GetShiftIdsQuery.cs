using AWC.Infrastructure.Persistence.Repositories;
using AWC.Infrastructure.Persistence.Repositories.Lookups;
using AWC.Shared.Queries.Lookups;
using AWC.SharedKernel.Utilities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Queries.Lookups
{
    public static class GetShiftIdsQuery
    {
        public async static Task<Result<List<ShiftId>>> Query
        (
            DapperContext ctx,
            ILogger<LookupsRepositoryManager> logger
        )
        {
            try
            {
                const string sql = LookupsQuerySql.GetShiftIds;

                using var connection = ctx.CreateConnection();
                var shiftIds = await connection.QueryAsync<ShiftId>(sql);

                if (shiftIds is null)
                {
                    return Result<List<ShiftId>>.Failure<List<ShiftId>>(
                        new Error("GetShiftIdsQuery.Query", "Oops! No shift ids found.")
                    );
                }

                return shiftIds.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Code Path: GetShiftIdsQuery.Query - Message: {Helpers.GetExceptionMessage(ex)}");
                return Result<List<ShiftId>>.Failure<List<ShiftId>>(
                    new Error("GetShiftIdsQuery.Query", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}