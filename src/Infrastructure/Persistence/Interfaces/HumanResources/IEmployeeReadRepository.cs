using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Interfaces.HumanResources
{
    public interface IEmployeeReadRepository
    {
        Task<Result<EmployeeDetailsForDisplay>> GetEmployeeDetailsByIdWithAllInfo(int employeeId);
        Task<Result<PagedList<EmployeeListItem>>> GetEmployeeListItemsSearchByLastName(string lastName, PagingParameters pagingParameters);
    }
}