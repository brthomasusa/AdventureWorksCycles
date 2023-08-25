using Fluxor;

namespace AWC.Client.Services.HumanResources.Store
{
    public sealed class EmployeeRepositoryFeature : Feature<EmployeeRepositoryState>
    {
        public override string GetName() => "EmployeeRepositoryState";

        protected override EmployeeRepositoryState GetInitialState() =>
            new()
            {
                Initialized = false,
                Loading = false,
                ErrorMessage = string.Empty,
                ManagerIDs = new(),
                StateCodes = new()
            };
    }
}