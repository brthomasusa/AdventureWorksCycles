using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyDepartments
{
    public sealed record GetCompanyDepartmentsSearchByNameRequest(string DepartmentName, PagingParameters PagingParameters) : IQuery<PagedList<GetCompanyDepartmentsResponse>>;
}