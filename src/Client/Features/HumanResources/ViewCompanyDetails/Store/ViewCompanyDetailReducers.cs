using Fluxor;

namespace AWC.Client.Features.HumanResources.ViewCompanyDetails.Store
{
    public static class ViewCompanyDetailReducers
    {
        [ReducerMethod(typeof(SetLoadingFlagAction))]
        public static ViewCompanyDetailState OnLoadingCompanyDetailsAction
        (
            ViewCompanyDetailState state
        )
        {
            return state with
            {
                Loading = true
            };
        }

        [ReducerMethod]
        public static ViewCompanyDetailState OnSetInitializeFlagAction
        (
            ViewCompanyDetailState state,
            ViewInitializeFlagAction action
        )
        {
            return state with
            {
                Initialized = action.IsInitialized
            };
        }

        [ReducerMethod]
        public static ViewCompanyDetailState OnGetCompanyDetailsSuccessAction
        (
            ViewCompanyDetailState state,
            ViewCompanyDetailsSuccessAction action
        )
        {
            return state with
            {
                DetailsModel = action.DetailModel,
                Loading = false,
                Initialized = true
            };
        }

        [ReducerMethod]
        public static ViewCompanyDetailState OnGetCompanyDetailsFailureMessageAction
        (
            ViewCompanyDetailState state,
            ViewCompanyDetailsFailureMessageAction action
        )
        {
            return state with
            {
                ErrorMessage = action.ErrorMessage,
                Loading = false,
                Initialized = false
            };
        }
    }
}