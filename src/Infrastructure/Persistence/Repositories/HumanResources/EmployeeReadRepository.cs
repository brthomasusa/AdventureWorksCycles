using AWC.Infrastructure.Persistence.Interfaces.HumanResources;
using AWC.Infrastructure.Persistence.Queries.HumanResources;
// using AWC.Shared.Models.HumanResources;
using AWC.SharedKernel.Utilities;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Repositories.HumanResources
{
    public sealed class EmployeeReadRepository : IEmployeeReadRepository
    {
        private readonly ILogger<ReadRepositoryManager> _logger;
        private readonly DapperContext _context;
        public EmployeeReadRepository(DapperContext ctx, ILogger<ReadRepositoryManager> logger)
        {
            _logger = logger;
            _context = ctx;
        }
    }
}