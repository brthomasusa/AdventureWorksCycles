#pragma warning disable CS8618

using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Interfaces.Lookups;
using AWC.Infrastructure.Persistence.Repositories.Lookups;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Repositories
{
    public sealed class LookupsRepositoryManager : ILookupsRepositoryManager
    {
        private readonly ILogger<LookupsRepositoryManager> _logger;
        private readonly DapperContext _context;
        private readonly Lazy<ILookupsRepository> _lookupsRepository;

        public LookupsRepositoryManager(DapperContext ctx, ILogger<LookupsRepositoryManager> logger)
        {
            _context = ctx;
            _logger = logger;

            _lookupsRepository = new Lazy<ILookupsRepository>(()
                => new LookupsRepository(_context, _logger));
        }

        public ILookupsRepository LookupsRepository => _lookupsRepository.Value;
    }
}