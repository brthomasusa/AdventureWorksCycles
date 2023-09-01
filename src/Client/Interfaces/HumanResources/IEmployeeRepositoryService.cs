using AWC.Client.Utilities;
using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.Shared.Queries.Shared;

namespace AWC.Client.Interfaces.HumanResources
{
    public interface IEmployeeRepositoryService
    {
        Task<Result<EmployeeDetails>> GetEmployeeDetails(int businessEntityID);
        Task<Result<PagedList<EmployeeListItem>>> GetEmployeeListItems(StringSearchCriteria criteria);
        Task<Result<List<StateCode>>> GetStateCodes();
        Task<Result<List<ManagerId>>> GetManagerIDs();
    }
}