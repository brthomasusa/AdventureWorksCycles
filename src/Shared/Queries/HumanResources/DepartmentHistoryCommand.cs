namespace AWC.Shared.Queries.HumanResources
{
    public sealed class DepartmentHistoryCommand
    {
        public int BusinessEntityID { get; set; }
        public int DepartmentID { get; set; }
        public int ShiftID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}