using AWC.Client.Services.HumanResources.Store;
using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Client.Services.HumanResources.Store.Managers;

public sealed record LoadManagerIdAsyncAction(TaskCompletionSource<List<ManagerId>> TaskCompletionSource);
