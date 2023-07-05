using AWC.Shared.Queries.HumanResources;

namespace AWC.Client.Features.HumanResources.ViewCompanyDetails.Store
{
    public sealed record ViewCompanyDetailState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public string? ErrorMessage { get; init; }
        public int CompanyID { get; init; }
        public CompanyDetails? DetailsModel { get; init; }
    }
}