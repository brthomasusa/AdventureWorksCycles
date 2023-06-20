using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.Lookups;

namespace AWC.Application.Lookups.GetStateCodesForUSA
{
    public sealed record GetStateCodeIdForUSARequest() : IQuery<List<StateCode>>;
}