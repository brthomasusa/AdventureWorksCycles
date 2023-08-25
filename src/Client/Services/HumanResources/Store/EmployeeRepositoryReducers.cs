using Fluxor;

namespace AWC.Client.Services.HumanResources.Store
{
    public static class EmployeeRepositoryReducers
    {
        [ReducerMethod]
        public static EmployeeRepositoryState OnLoadingStateCodesSuccessAction
        (
            EmployeeRepositoryState state,
            LoadStateCodesSuccessAction action
        )
        {
            Console.WriteLine($"EmployeeRepositoryReducers.OnLoadingStateCodesSuccessAction: {action.StateCodes!.Count} StateCodes returned.");
            return state with
            {
                Initialized = true,
                StateCodes = action.StateCodes
            };
        }

        [ReducerMethod]
        public static EmployeeRepositoryState OnLoadingStateCodesFailureAction
        (
            EmployeeRepositoryState state,
            LoadStateCodesFailureAction action
        )
        {
            return state with
            {
                ErrorMessage = action.ErrorMessage
            };
        }
    }
}