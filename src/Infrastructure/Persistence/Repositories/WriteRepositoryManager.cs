using AWC.Core.Interfaces;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories.HumanResources;
using Microsoft.Extensions.Logging;
using MapsterMapper;

namespace AWC.Infrastructure.Persistence.Repositories
{
    public class WriteRepositoryManager : IWriteRepositoryManager
    {
        private readonly ILogger<WriteRepositoryManager> _logger;
        private readonly AwcContext _context;
        private readonly Lazy<IEmployeeWriteRepository> _employeeRepository;
        private readonly Lazy<ICompanyWriteRepository> _companyRepository;
        private readonly IMapper _mapper;

        public WriteRepositoryManager
        (
            AwcContext context,
            ILogger<WriteRepositoryManager> logger,
            IMapper mapper
        )
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;

            _employeeRepository = new Lazy<IEmployeeWriteRepository>(()
                => new EmployeeWriteRepository(_context, _logger, _mapper));

            _companyRepository = new Lazy<ICompanyWriteRepository>(()
                => new CompanyWriteRepository(_context, _logger, _mapper));
        }

        public IEmployeeWriteRepository EmployeeAggregateRepository => _employeeRepository.Value;
        public ICompanyWriteRepository CompanyAggregateRepository => _companyRepository.Value;
    }
}