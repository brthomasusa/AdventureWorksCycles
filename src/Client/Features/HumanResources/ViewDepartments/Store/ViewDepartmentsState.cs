using AWC.Client.Utilities;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;

namespace AWC.Client.Features.HumanResources.ViewDepartments.Store
{
    public sealed record ViewDepartmentsState
    {
        public bool Initialized { get; init; }
        public bool Loading { get; init; }
        public string? ErrorMessage { get; init; }
        public List<DepartmentDetails>? DepartmentList { get; init; }
        public MetaData? MetaData { get; set; }
        public StringSearchCriteria? SearchCriteria { get; set; }
    }
}