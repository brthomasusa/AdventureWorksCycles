using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.Lookups.Shared;

namespace AWC.Application.Lookups.Shared.GetStateCodesForUSA
{
    public sealed record GetStateCodeIdForUsaRequest(int SuppressSonarqubeWarning = 0) : IQuery<List<StateCode>>;
}