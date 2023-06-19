using AWC.Infrastructure.Persistence.Interfaces.Lookups;
using AWC.Infrastructure.Persistence.Queries.Lookups;
using AWC.Shared.Queries.Lookups;
using AWC.SharedKernel.Utilities;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Repositories.Lookups
{
    public sealed class LookupsRepository : ILookupsRepository
    {
        private readonly ILogger<LookupsRepositoryManager> _logger;
        private readonly DapperContext _context;

        public LookupsRepository(DapperContext ctx, ILogger<LookupsRepositoryManager> logger)
            => (_context, _logger) = (ctx, logger);

        public async Task<Result<List<StateCode>>> StateCodeIdUSA()
            => await GetStateCodeIdUSAQuery.Query(_context, _logger);

        public async Task<Result<List<StateCode>>> StateCodeIdAll()
            => await GetStateCodeIdAllQuery.Query(_context, _logger);

        public async Task<Result<List<DepartmentId>>> DepartmentIds()
            => await GetDepartmentIdsQuery.Query(_context, _logger);

        public async Task<Result<List<ShiftId>>> ShiftIds()
            => await GetShiftIdsQuery.Query(_context, _logger);
    }
}