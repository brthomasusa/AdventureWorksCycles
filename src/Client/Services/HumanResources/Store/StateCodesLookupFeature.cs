using Fluxor;

namespace AWC.Client.Services.HumanResources.Store
{
    public sealed class StateCodesLookupFeature : Feature<StateCodesLookupState>
    {
        public override string GetName() => "StateCodesLookupState";

        protected override StateCodesLookupState GetInitialState() =>
            new()
            {
                Initialized = false,
                Loading = false,
                ErrorMessage = string.Empty,
                StateCodes = new(),
            };
    }
}