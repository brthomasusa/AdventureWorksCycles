using Fluxor;
using AWC.Client.Utilities;

namespace AWC.Client.Services.HumanResources.Store;

public static class LoadManagerIdReducers
{
    [ReducerMethod(typeof(SetManagerIDsLoadingFlagAction))]
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
    public static EmployeeRepositoryState OnLoadManagerIDsSuccessAction
    (
        EmployeeRepositoryState state,
        LoadManagerIdAsyncSuccessAction action
    )
    {
        return state with
        {
            Loading = false,
            ManagerIDs = action.Managers
        };
    }

    [ReducerMethod]
    public static EmployeeRepositoryState OnLoadManagerIDsFailureAction
    (
        EmployeeRepositoryState state,
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
