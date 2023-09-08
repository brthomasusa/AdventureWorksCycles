using AWC.Shared.Queries.Lookups.Shared;

namespace AWC.Client.Services.HumanResources.Store
{
    public sealed record StateCodesLookupState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public string? ErrorMessage { get; init; }
        public List<StateCode>? StateCodes { get; init; }
    }
}