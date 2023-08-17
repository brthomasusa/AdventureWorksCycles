namespace AWC.Shared.Queries.HumanResources
{
    public sealed class PayHistory
    {
        public int BusinessEntityID { get; set; }
        public DateTime RateChangeDate { get; set; }
        public decimal Rate { get; set; }
        public string? PayFrequency { get; set; }
    }
}