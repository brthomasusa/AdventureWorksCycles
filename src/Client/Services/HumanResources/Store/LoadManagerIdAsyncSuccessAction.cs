using AWC.Shared.Queries.Lookups.Shared;
using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Client.Services.HumanResources.Store
{
    public sealed record LoadManagerIdAsyncSuccessAction(List<ManagerId> Managers);
}