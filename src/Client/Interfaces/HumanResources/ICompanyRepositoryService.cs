using AWC.Client.Utilities;
using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Client.Interfaces.HumanResources
{
    public interface ICompanyRepositoryService
    {
        Task<Result<List<DepartmentId>>> GetDepartmentIDs();
        Task<Result<List<ShiftId>>> GetShiftIDs();
    }
}