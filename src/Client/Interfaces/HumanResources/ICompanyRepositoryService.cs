using AWC.Client.Utilities;
using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.Shared.Queries.Shared;

namespace AWC.Client.Interfaces.HumanResources
{
    public interface ICompanyRepositoryService
    {
        Task<Result<List<DepartmentId>>> GetDepartmentIDs();
        Task<Result<List<ShiftId>>> GetShiftIDs();
    }
}