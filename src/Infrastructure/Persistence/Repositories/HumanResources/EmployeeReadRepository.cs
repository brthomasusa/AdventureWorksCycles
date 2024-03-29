using AWC.Infrastructure.Persistence.Interfaces.HumanResources;
using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
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

        public async Task<Result<EmployeeDetails>> GetEmployeeDetails(int employeeId)
            => await GetEmployeeDetailsQuery.Query(employeeId, _context, _logger);

        public async Task<Result<EmployeeGenericCommand>> GetEmployeeGenericCommand(int employeeId)
            => await GetEmployeeGenericCommandQuery.Query(employeeId, _context, _logger);

        public async Task<Result<PagedList<EmployeeListItem>>> GetEmployeeListItemsSearchByLastName(StringSearchCriteria searchCriteria)
            => await GetEmployeeListItemsQuery.Query(searchCriteria, _context, _logger);

        public async Task<Result<List<DepartmentHistory>>> GetDepartmentHistories(int businessEntityID)
            => await GetDepartmentHistoriesQuery.Query(businessEntityID, _context, _logger);

        public async Task<Result<List<DepartmentHistoryCommand>>> GetDepartmentHistoryCommands(int businessEntityID)
            => await GetDepartmentHistoriesCommandQuery.Query(businessEntityID, _context, _logger);

        public async Task<Result<List<PayHistory>>> GetPayHistories(int businessEntityID)
            => await GetPayHistoriesQuery.Query(businessEntityID, _context, _logger);

        public async Task<Result<List<PayHistoryCommand>>> GetPayHistoryCommands(int businessEntityID)
            => await GetPayHistoryCommandsQuery.Query(businessEntityID, _context, _logger);
    }
}