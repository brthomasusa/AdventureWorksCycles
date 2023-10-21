using AWC.Infrastructure.Persistence.Interfaces.Lookups;
using AWC.Infrastructure.Persistence.Queries.Lookups;
using AWC.Infrastructure.Persistence.Queries.Lookups.Shared;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.SharedKernel.Utilities;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Repositories.Lookups
{
    public sealed class SharedLookupsRepository : ISharedLookupsRepository
    {
        private readonly ILogger<LookupsRepositoryManager> _logger;
        private readonly DapperContext _context;

        public SharedLookupsRepository(DapperContext ctx, ILogger<LookupsRepositoryManager> logger)
            => (_context, _logger) = (ctx, logger);

        public async Task<Result<List<StateCode>>> StateCodeIdUSA()
            => await GetStateCodeIdUsaQuery.Query(_context, _logger);

        public async Task<Result<List<CountryCode>>> CountryRegionCode()
            => await GetCountryCodesQuery.Query(_context, _logger);

        public async Task<Result<List<StateCode>>> StateCodeIdAll()
            => await GetStateCodeIdAllQuery.Query(_context, _logger);
    }
}