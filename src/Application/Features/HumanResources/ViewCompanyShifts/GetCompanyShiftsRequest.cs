using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyShifts
{
    public sealed record GetCompanyShiftsRequest(PagingParameters PagingParameters) : IQuery<PagedList<GetCompanyShiftsResponse>>;
}