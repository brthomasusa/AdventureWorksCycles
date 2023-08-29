using Fluxor;

namespace AWC.Client.Services.HumanResources.Store
{
    public static class LoadStateCodesReducers
    {
        [ReducerMethod(typeof(SetStateCodesLoadingFlagAction))]
        public static EmployeeRepositoryState OnLoadingStateCodesAction
        (
            EmployeeRepositoryState state
        )
        {
            return state with
            {
                Loading = true
            };
        }

        [ReducerMethod]
        public static EmployeeRepositoryState OnLoadingStateCodesSuccessAction
        (
            EmployeeRepositoryState state,
            LoadStateCodesSuccessAction action
        )
        {
            return state with
            {
                Initialized = true,
                Loading = false,
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
                Initialized = false,
                Loading = false,
                ErrorMessage = action.ErrorMessage
            };
        }
    }
}