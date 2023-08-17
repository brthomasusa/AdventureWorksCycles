using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Application.Lookups.HumanResources.GetShiftIds
{
    public sealed record GetShiftIdsRequest() : IQuery<List<ShiftId>>;
}