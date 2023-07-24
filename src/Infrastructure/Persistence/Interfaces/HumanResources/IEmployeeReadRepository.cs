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
    }
}