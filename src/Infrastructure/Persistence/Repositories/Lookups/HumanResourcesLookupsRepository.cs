using AWC.Infrastructure.Persistence.Interfaces.Lookups;
using AWC.Infrastructure.Persistence.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.SharedKernel.Utilities;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Repositories.Lookups
{
    public sealed class HumanResourcesLookupsRepository : IHumanResourcesLookupsRepository
    {
        private readonly ILogger<LookupsRepositoryManager> _logger;
        private readonly DapperContext _context;

        public HumanResourcesLookupsRepository(DapperContext ctx, ILogger<LookupsRepositoryManager> logger)
            => (_context, _logger) = (ctx, logger);

        public async Task<Result<List<DepartmentId>>> DepartmentIds()
            => await GetDepartmentIdsQuery.Query(_context, _logger);

        public async Task<Result<List<ShiftId>>> ShiftIds()
            => await GetShiftIdsQuery.Query(_context, _logger);
    }
}