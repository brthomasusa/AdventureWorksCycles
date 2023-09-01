using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Client.Services.HumanResources.Store.Shifts
{
    public sealed record LoadShiftIdAsyncSuccessAction(List<ShiftId> Shifts);
}