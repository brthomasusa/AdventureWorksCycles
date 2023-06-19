namespace AWC.Infrastructure.Persistence.DataModels.HumanResources
{
    public sealed class EmployeePayHistory
    {
        public int BusinessEntityID { get; set; }
        public DateTime RateChangeDate { get; set; }
        public decimal Rate { get; set; }
        public byte PayFrequency { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
