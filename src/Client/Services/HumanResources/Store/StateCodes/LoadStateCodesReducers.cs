using Fluxor;

namespace AWC.Client.Services.HumanResources.Store.StateCodes
{
    public static class LoadStateCodesReducers
    {
        [ReducerMethod(typeof(SetStateCodesLoadingFlagAction))]
        public static StateCodesLookupState OnLoadingStateCodesAction
        (
            StateCodesLookupState state
        )
        {
            return state with
            {
                Loading = true
            };
        }

        [ReducerMethod]
        public static StateCodesLookupState OnLoadingStateCodesSuccessAction
        (
            StateCodesLookupState state,
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
        public static StateCodesLookupState OnLoadingStateCodesFailureAction
        (
            StateCodesLookupState state,
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