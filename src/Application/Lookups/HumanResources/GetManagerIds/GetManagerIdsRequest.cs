using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Application.Lookups.HumanResources.GetManagerIds
{
    public sealed record GetManagerIdsRequest(int SuppressSonarqubeWarning = 0) : IQuery<List<ManagerId>>;
}