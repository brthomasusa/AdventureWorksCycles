using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewEmployees
{
    public sealed record GetEmployeeListItemsRequest(StringSearchCriteria SearchCriteria) : IQuery<PagedList<EmployeeListItem>>;
}