namespace AWC.Shared.Queries.HumanResources
{
    public sealed class DepartmentDetails
    {
        public int DepartmentID { get; set; }
        public string? Name { get; set; }
        public string? GroupName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}