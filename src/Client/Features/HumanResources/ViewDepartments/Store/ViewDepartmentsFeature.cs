using AWC.Shared.Queries.Shared;
using Fluxor;

namespace AWC.Client.Features.HumanResources.ViewDepartments.Store
{
    public sealed class ViewDepartmentsFeature : Feature<ViewDepartmentsState>
    {
        public override string GetName() => "ViewDepartments";

        protected override ViewDepartmentsState GetInitialState() =>
            new()
            {
                Initialized = false,
                Loading = false,
                ErrorMessage = string.Empty,
                DepartmentList = new(),
                MetaData = new() { CurrentPage = 1, PageSize = 15 },
                SearchCriteria = new StringSearchCriteria
                (
                    SearchField: "Name",
                    SearchCriteria: string.Empty,
                    OrderBy: "Name",
                    PageNumber: 1,
                    PageSize: 10
                )
            };
    }
}