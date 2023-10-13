using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.Lookups.Shared;

namespace AWC.Application.Lookups.Shared.GetStateCodesForAll
{
    public sealed record GetStateCodeIdForAllRequest(int SuppressSonarqubeWarning = 0) : IQuery<List<StateCode>>;
}