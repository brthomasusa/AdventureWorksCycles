using AWC.Core.Interfaces;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories.HumanResources;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Repositories
{
    public sealed class ValidationRepositoryManager : IValidationRepositoryManager
    {
        private readonly ILogger<WriteRepositoryManager> _logger;
        private readonly AwcContext _context;
        private readonly Lazy<IEmployeeValidationRepository> _employeeRepository;
        private readonly Lazy<ICompanyValidationRepository> _companyRepository;

        public ValidationRepositoryManager
        (
            AwcContext context,
            ILogger<WriteRepositoryManager> logger
        )
        {
            _context = context;
            _logger = logger;

            _employeeRepository = new Lazy<IEmployeeValidationRepository>(()
                => new EmployeeValidationRepository(_context, _logger));

            _companyRepository = new Lazy<ICompanyValidationRepository>(()
                => new CompanyValidationRepository(_context, _logger));
        }

        public IEmployeeValidationRepository EmployeeAggregateRepository => _employeeRepository.Value;
        public ICompanyValidationRepository CompanyAggregateRepository => _companyRepository.Value;
    }
}