using Fluxor;

namespace AWC.Client.Services.HumanResources.Store.Managers;

public static class LoadManagerIdReducers
{
    [ReducerMethod(typeof(SetManagerIDsLoadingFlagAction))]
    public static ManagerIdLookupState OnLoadingSManagerIdsAction
    (
        ManagerIdLookupState state
    )
    {
        return state with
        {
            Loading = true
        };
    }

    [ReducerMethod]
    public static ManagerIdLookupState OnLoadManagerIdsSuccessAction
    (
        ManagerIdLookupState state,
        LoadManagerIdAsyncSuccessAction action
    )
    {
        return state with
        {
            Loading = false,
            ManagerIds = action.Managers
        };
    }

    [ReducerMethod]
    public static ManagerIdLookupState OnLoadManagerIdsFailureAction
    (
        ManagerIdLookupState state,
        LoadManagerIdAsyncFailureAction action
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
