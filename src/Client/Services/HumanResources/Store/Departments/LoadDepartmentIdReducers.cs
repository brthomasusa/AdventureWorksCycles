using Fluxor;

namespace AWC.Client.Services.HumanResources.Store.Departments
{
    public static class LoadDepartmentIdReducers
    {
        [ReducerMethod(typeof(LoadDepartmentIdAsyncAction))]
        public static DepartmentIdLookupState OnLoadDepartmentIdAsyncAction
        (
            DepartmentIdLookupState state
        )
        {
            return state with
            {
                Loading = true
            };
        }

        [ReducerMethod]
        public static DepartmentIdLookupState OnLoadDepartmentIDsSuccessAction
        (
            DepartmentIdLookupState state,
            LoadDepartmentIdAsyncSuccessAction action
        )
        {
            return state with
            {
                Loading = false,
                DepartmentIds = action.Departments
            };
        }

        [ReducerMethod]
        public static DepartmentIdLookupState OnLoadDepartmentIDsFailureAction
        (
            DepartmentIdLookupState state,
            LoadDepartmentIdAsyncFailureAction action
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