using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Client.Services.HumanResources.Store.Departments
{
    public sealed record LoadDepartmentIdAsyncAction(TaskCompletionSource<List<DepartmentId>> TaskCompletionSource);
}