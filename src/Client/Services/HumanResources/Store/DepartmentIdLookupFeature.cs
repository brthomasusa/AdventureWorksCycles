using Fluxor;

namespace AWC.Client.Services.HumanResources.Store
{
    public sealed class DepartmentIdLookupFeature : Feature<DepartmentIdLookupState>
    {
        public override string GetName() => "DepartmentIdLookupState";

        protected override DepartmentIdLookupState GetInitialState() =>
            new()
            {
                Initialized = false,
                Loading = false,
                ErrorMessage = string.Empty,
                DepartmentIds = new(),
            };
    }
}