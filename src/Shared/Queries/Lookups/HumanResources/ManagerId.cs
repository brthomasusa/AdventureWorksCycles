namespace AWC.Shared.Queries.Lookups.HumanResources
{
    public sealed class ManagerId
    {
        public int BusinessEntityID { get; set; }
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public string? JobTitle { get; set; }
        public string? ManagerFullName { get; set; }
    }
}