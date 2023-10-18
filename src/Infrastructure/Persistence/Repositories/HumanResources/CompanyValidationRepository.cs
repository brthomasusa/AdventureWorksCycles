using AWC.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Repositories.HumanResources
{
    public sealed class CompanyValidationRepository : ICompanyValidationRepository
    {
        private readonly ILogger<WriteRepositoryManager> _logger;
        private readonly AwcContext _context;

        public CompanyValidationRepository(AwcContext ctx, ILogger<WriteRepositoryManager> logger)
        {
            _context = ctx;
            _logger = logger;
        }
    }
}