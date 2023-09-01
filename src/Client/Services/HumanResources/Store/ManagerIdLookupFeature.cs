using Fluxor;

namespace AWC.Client.Services.HumanResources.Store
{
    public sealed class ManagerIdLookupFeature : Feature<ManagerIdLookupState>
    {
        public override string GetName() => "ManagerIdLookupState";

        protected override ManagerIdLookupState GetInitialState() =>
            new()
            {
                Initialized = false,
                Loading = false,
                ErrorMessage = string.Empty,
                ManagerIds = new(),
            };
    }
}