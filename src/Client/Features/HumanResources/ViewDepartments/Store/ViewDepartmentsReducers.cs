using AWC.Client.Utilities;

using Fluxor;
namespace AWC.Client.Features.HumanResources.ViewDepartments.Store
{
    public static class ViewDepartmentsReducers
    {
        [ReducerMethod(typeof(SetLoadingFlagAction))]
        public static ViewDepartmentsState OnLoadingCompanyDepartmentsAction
        (
            ViewDepartmentsState state
        )
        {
            return state with
            {
                Loading = true
            };
        }

        [ReducerMethod]
        public static ViewDepartmentsState OnGetCompanyDepartmentsSuccessAction
        (
            ViewDepartmentsState state,
            GetDepartmentsSuccessAction action
        )
        {
            return state with
            {
                DepartmentList = action.Departments,
                MetaData = action.MetaData,
                Loading = false,
                Initialized = true,
                SearchCriteria = action.SearchCriteria
            };
        }

        [ReducerMethod]
        public static ViewDepartmentsState OnGetCompanyDepartmentsFailureMessageAction
        (
            ViewDepartmentsState state,
            GetDepartmentsFailureAction action
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