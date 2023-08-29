using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Client.Services.HumanResources.Store;

public sealed record LoadManagerIdAsyncAction(TaskCompletionSource<List<ManagerId>> TaskCompletionSource);
