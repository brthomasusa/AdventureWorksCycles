using AWC.Shared.Queries.Lookups.Shared;

namespace AWC.Client.Features.HumanResources.UpdateCompanyDetails.Store
{
    public sealed record LoadStateCodesSuccessAction(List<StateCode>? StateCodes);
}