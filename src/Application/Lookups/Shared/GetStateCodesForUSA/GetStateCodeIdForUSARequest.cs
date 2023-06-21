using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.Lookups.Shared;

namespace AWC.Application.Lookups.Shared.GetStateCodesForUSA
{
    public sealed record GetStateCodeIdForUSARequest() : IQuery<List<StateCode>>;
}