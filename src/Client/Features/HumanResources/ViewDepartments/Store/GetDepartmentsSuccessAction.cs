using AWC.Client.Utilities;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;

namespace AWC.Client.Features.HumanResources.ViewDepartments.Store
{
    public record GetDepartmentsSuccessAction(List<DepartmentDetails> Departments, MetaData MetaData, StringSearchCriteria SearchCriteria);
}