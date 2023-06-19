using AWC.Shared.Queries.Lookups;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Interfaces.Lookups
{
    public interface ILookupsRepository
    {
        Task<Result<List<StateCode>>> StateCodeIdUSA();
        Task<Result<List<StateCode>>> StateCodeIdAll();
        Task<Result<List<DepartmentId>>> DepartmentIds();
        Task<Result<List<ShiftId>>> ShiftIds();
    }
}