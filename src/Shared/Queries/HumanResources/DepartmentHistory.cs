namespace AWC.Shared.Queries.HumanResources
{
    public sealed class DepartmentHistory
    {
        public int BusinessEntityID { get; set; }
        public string? Department { get; set; }
        public string? Shift { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}