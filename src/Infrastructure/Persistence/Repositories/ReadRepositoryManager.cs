#pragma warning disable CS8618

using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Interfaces.HumanResources;
using AWC.Infrastructure.Persistence.Repositories.HumanResources;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Repositories
{
    public sealed class ReadRepositoryManager : IReadRepositoryManager
    {
        private readonly ILogger<ReadRepositoryManager> _logger;
        private readonly DapperContext _context;
        private readonly Lazy<IEmployeeReadRepository> _employeeRepository;
        private readonly Lazy<ICompanyReadRepository> _companyRepository;

        public ReadRepositoryManager(DapperContext ctx, ILogger<ReadRepositoryManager> logger)
        {
            _context = ctx;
            _logger = logger;

            _employeeRepository = new Lazy<IEmployeeReadRepository>(()
                => new EmployeeReadRepository(_context, _logger));

            _companyRepository = new Lazy<ICompanyReadRepository>(()
                => new CompanyReadRepository(_context, _logger));
        }

        public IEmployeeReadRepository EmployeeReadRepository => _employeeRepository.Value;
        public ICompanyReadRepository CompanyReadRepository => _companyRepository.Value;
    }
}