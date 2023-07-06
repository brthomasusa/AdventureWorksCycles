using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;

namespace AWC.Client.Features.HumanResources.UpdateCompanyDetails.Store
{
    public sealed record UpdateCompanyDetailsState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public bool Submitting { get; init; }
        public bool Submitted { get; init; }
        public string? ErrorMessage { get; init; }
        public int CompanyID { get; init; }
        public CompanyGenericCommand? CommandModel { get; init; }
        public List<StateCode>? StateCodes { get; init; }
    }
}