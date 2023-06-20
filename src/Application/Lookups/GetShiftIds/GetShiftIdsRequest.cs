using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.Lookups;

namespace AWC.Application.Lookups.GetShiftIds
{
    public sealed record GetShiftIdsRequest() : IQuery<List<ShiftId>>;
}