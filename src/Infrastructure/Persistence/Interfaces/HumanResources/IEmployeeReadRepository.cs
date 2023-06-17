using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Interfaces.HumanResources
{
    public interface IEmployeeReadRepository
    {
        Task<Result<EmployeeDetailReadModel>> GetEmployeeDetailsByIdWithAllInfo(int employeeId);
        Task<Result<PagedList<EmployeeListItemReadModel>>> GetEmployeeListItemsSearchByLastName(string lastName, PagingParameters pagingParameters);
    }
}