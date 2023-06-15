namespace AWC.Shared.Queries.HumanResources
{
    public class ShiftReadModel
    {
        public int ShiftID { get; set; }
        public string? Name { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}