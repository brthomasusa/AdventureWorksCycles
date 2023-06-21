using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Application.Lookups.HumanResources.GetManagerIds
{
    public sealed record GetManagerIdsRequest() : IQuery<List<ManagerId>>;
}