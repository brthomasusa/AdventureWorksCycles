using AWC.Shared.Queries.Lookups.Shared;

namespace AWC.Client.Services.HumanResources.Store.StateCodes
{
    public sealed record LoadStateCodesSuccessAction(List<StateCode>? StateCodes);
}