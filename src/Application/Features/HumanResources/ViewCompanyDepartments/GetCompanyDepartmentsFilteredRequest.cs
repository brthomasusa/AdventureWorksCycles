using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyDepartments
{
    public sealed record GetCompanyDepartmentsFilteredRequest(StringSearchCriteria SearchCriteria) : IQuery<PagedList<DepartmentDetails>>;


}