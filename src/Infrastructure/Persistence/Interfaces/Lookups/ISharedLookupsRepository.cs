using AWC.Shared.Queries.Lookups.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Interfaces.Lookups
{
    public interface ISharedLookupsRepository
    {
        Task<Result<List<StateCode>>> StateCodeIdUSA();
        Task<Result<List<StateCode>>> StateCodeIdAll();
        Task<Result<List<CountryCode>>> CountryRegionCode();
    }
}