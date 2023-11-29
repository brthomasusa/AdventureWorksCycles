using AWC.Core.Interfaces.HumanResouces;
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
        private IEmployeeWriteRepository? _employeeRepository;
        private ICompanyWriteRepository? _companyRepository;
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
        }

        public IEmployeeWriteRepository EmployeeAggregateRepository
        {
            get
            {
                _employeeRepository ??= new EmployeeWriteRepository(_context, _logger, _mapper);

                return _employeeRepository;
            }
        }

        public ICompanyWriteRepository CompanyAggregateRepository
        {
            get
            {
                _companyRepository ??= new CompanyWriteRepository(_context, _logger, _mapper);

                return _companyRepository;
            }
        }


        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);

    }
}