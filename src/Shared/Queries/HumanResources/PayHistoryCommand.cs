namespace AWC.Shared.Queries.HumanResources
{
    public sealed class PayHistoryCommand
    {
        public int BusinessEntityID { get; set; }
        public DateTime RateChangeDate { get; set; }
        public decimal Rate { get; set; }
        public int PayFrequency { get; set; }
    }
}