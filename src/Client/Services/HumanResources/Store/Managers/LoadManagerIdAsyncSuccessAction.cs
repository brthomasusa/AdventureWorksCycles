using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Client.Services.HumanResources.Store.Managers
{
    public sealed record LoadManagerIdAsyncSuccessAction(List<ManagerId> Managers);
}