using Ardalis.Specification.EntityFrameworkCore;
using AWC.Core.HumanResources;
using AWC.Core.Interfaces;
using AWC.Infrastructure.Persistence.Mappings.HumanResources;
using AWC.Infrastructure.Persistence.Specifications.HumanResources;
using AWC.SharedKernel.Interfaces;
using AWC.SharedKernel.Utilities;
using Microsoft.EntityFrameworkCore;
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