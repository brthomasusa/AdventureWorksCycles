using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyDetails
{
    public sealed record GetEmployeeListItemsRequest(string LastName, PagingParameters PagingParameters) : IQuery<PagedList<EmployeeListItemReadModel>>;
}