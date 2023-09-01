using Fluxor;

namespace AWC.Client.Services.HumanResources.Store
{
    public sealed class ShiftIdLookupFeature : Feature<ShiftIdLookupState>
    {
        public override string GetName() => "ShiftIdLookupState";

        protected override ShiftIdLookupState GetInitialState() =>
            new()
            {
                Initialized = false,
                Loading = false,
                ErrorMessage = string.Empty,
                ShiftIds = new(),
            };
    }
}