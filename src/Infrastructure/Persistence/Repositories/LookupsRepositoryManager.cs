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
        private readonly Lazy<IHumanResourcesLookupsRepository> _humanResourcesRepository;
        private readonly Lazy<ISharedLookupsRepository> _sharedRepository;

        public LookupsRepositoryManager(DapperContext ctx, ILogger<LookupsRepositoryManager> logger)
        {
            _context = ctx;
            _logger = logger;

            _humanResourcesRepository = new Lazy<IHumanResourcesLookupsRepository>(()
                => new HumanResourcesLookupsRepository(_context, _logger));

            _sharedRepository = new Lazy<ISharedLookupsRepository>(()
                => new SharedLookupsRepository(_context, _logger));
        }

        public IHumanResourcesLookupsRepository HumanResourcesLookupsRepository => _humanResourcesRepository.Value;
        public ISharedLookupsRepository SharedLookupsRepository => _sharedRepository.Value;
    }
}