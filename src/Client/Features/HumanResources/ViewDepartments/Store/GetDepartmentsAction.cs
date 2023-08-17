using AWC.Shared.Queries.Shared;

namespace AWC.Client.Features.HumanResources.ViewDepartments.Store
{
    public sealed record GetDepartmentsAction(StringSearchCriteria SearchCriteria);
}