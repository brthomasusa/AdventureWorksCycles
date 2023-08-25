using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;

namespace AWC.Client.Services.HumanResources.Store
{
    public sealed record EmployeeRepositoryState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public string? ErrorMessage { get; init; }
        public List<ManagerId>? ManagerIDs { get; init; }
        public List<StateCode>? StateCodes { get; init; }
    }
}