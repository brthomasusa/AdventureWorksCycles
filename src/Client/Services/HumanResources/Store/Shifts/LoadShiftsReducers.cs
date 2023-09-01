using Fluxor;

namespace AWC.Client.Services.HumanResources.Store.Shifts
{
    public static class LoadShiftsReducers
    {
        [ReducerMethod(typeof(LoadShiftIdAsyncAction))]
        public static ShiftIdLookupState OnLoadShiftIdAsyncAction
        (
            ShiftIdLookupState state
        )
        {
            return state with
            {
                Loading = true
            };
        }

        [ReducerMethod]
        public static ShiftIdLookupState OnLoadShiftIdAsyncSuccessAction
        (
            ShiftIdLookupState state,
            LoadShiftIdAsyncSuccessAction action
        )
        {
            return state with
            {
                Loading = false,
                ShiftIds = action.Shifts
            };
        }

        [ReducerMethod]
        public static ShiftIdLookupState OnLoadShiftIdAsyncFailureAction
        (
            ShiftIdLookupState state,
            LoadShiftIdAsyncFailureAction action
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