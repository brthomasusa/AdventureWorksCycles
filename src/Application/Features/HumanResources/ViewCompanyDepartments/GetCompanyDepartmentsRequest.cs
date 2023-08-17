using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyDepartments
{
    public sealed record GetCompanyDepartmentsRequest(PagingParameters PagingParameters) : IQuery<PagedList<DepartmentDetails>>;
}