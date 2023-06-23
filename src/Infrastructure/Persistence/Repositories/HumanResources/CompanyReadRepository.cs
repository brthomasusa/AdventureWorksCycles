using AWC.Infrastructure.Persistence.Interfaces.HumanResources;
using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Repositories.HumanResources
{
    public sealed class CompanyReadRepository : ICompanyReadRepository
    {
        private readonly ILogger<ReadRepositoryManager> _logger;
        private readonly DapperContext _context;

        public CompanyReadRepository(DapperContext ctx, ILogger<ReadRepositoryManager> logger)
        {
            _logger = logger;
            _context = ctx;
        }

        public async Task<Result<CompanyDetailsForDisplay>> GetCompanyDetails(int companyId)
            => await GetCompanyDetailsQuery.Query(companyId, _context, _logger);

        public async Task<Result<CompanyDetailsForEdit>> GetCompanyCommand(int companyId)
            => await GetCompanyCommandQuery.Query(companyId, _context, _logger);

        public async Task<Result<PagedList<DepartmentDetails>>> GetCompanyDepartments(PagingParameters pagingParameters)
            => await GetCompanyDepartmentsQuery.Query(pagingParameters, _context, _logger);

        public async Task<Result<PagedList<DepartmentDetails>>> GetCompanyDepartmentsSearchByName(string deptName, PagingParameters pagingParameters)
            => await GetCompanyDepartmentsByNameQuery.Query(deptName, pagingParameters, _context, _logger);

        public async Task<Result<PagedList<ShiftDetails>>> GetCompanyShifts(PagingParameters pagingParameters)
            => await GetCompanyShiftsQuery.Query(pagingParameters, _context, _logger);
    }
}