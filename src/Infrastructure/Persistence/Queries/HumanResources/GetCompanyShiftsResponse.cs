namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public sealed class GetCompanyShiftsResponse
    {
        public int ShiftID { get; set; }
        public string? Name { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}