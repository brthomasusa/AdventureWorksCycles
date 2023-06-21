namespace AWC.Shared.Queries.HumanResources
{
    public class DepartmentDetailsResponse
    {
        public int DepartmentID { get; set; }
        public string? Name { get; set; }
        public string? GroupName { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}