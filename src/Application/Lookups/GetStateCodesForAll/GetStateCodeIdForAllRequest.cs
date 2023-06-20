using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.Lookups;

namespace AWC.Application.Lookups.GetStateCodesForAll
{
    public sealed record GetStateCodeIdForAllRequest() : IQuery<List<StateCode>>;
}