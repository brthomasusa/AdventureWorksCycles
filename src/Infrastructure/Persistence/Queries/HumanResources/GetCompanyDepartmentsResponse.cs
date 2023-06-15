namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public sealed class GetCompanyDepartmentsResponse
    {
        public int DepartmentID { get; set; }
        public string? Name { get; set; }
        public string? GroupName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}