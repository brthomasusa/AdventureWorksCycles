using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Interfaces.Lookups
{
    public interface IHumanResourcesLookupsRepository
    {
        Task<Result<List<DepartmentId>>> DepartmentIds();
        Task<Result<List<ShiftId>>> ShiftIds();
    }
}