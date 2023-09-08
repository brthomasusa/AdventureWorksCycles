using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Client.Services.HumanResources.Store.Departments
{
    public sealed record LoadDepartmentIdAsyncSuccessAction(List<DepartmentId> Departments);
}