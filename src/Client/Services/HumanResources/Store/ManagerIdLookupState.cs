using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Client.Services.HumanResources.Store
{
    public sealed record ManagerIdLookupState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public string? ErrorMessage { get; init; }
        public List<ManagerId>? ManagerIds { get; init; }
    }
}