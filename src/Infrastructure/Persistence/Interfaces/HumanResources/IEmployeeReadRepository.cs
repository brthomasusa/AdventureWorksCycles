using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Interfaces.HumanResources
{
    public interface IEmployeeReadRepository
    {
        Task<Result<EmployeeDetails>> GetEmployeeDetails(int employeeId);
        Task<Result<EmployeeGenericCommand>> GetEmployeeGenericCommand(int employeeId);
        Task<Result<PagedList<EmployeeListItem>>> GetEmployeeListItemsSearchByLastName(StringSearchCriteria searchCriteria);
        Task<Result<List<DepartmentHistory>>> GetDepartmentHistories(int businessEntityID);
        Task<Result<List<DepartmentHistoryCommand>>> GetDepartmentHistoryCommands(int businessEntityID);
        Task<Result<List<PayHistory>>> GetPayHistories(int businessEntityID);
        Task<Result<List<PayHistoryCommand>>> GetPayHistoryCommands(int businessEntityID);
    }
}