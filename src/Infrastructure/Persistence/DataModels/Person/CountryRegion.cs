namespace AWC.Infrastructure.Persistence.DataModels.Person
{
    public sealed class CountryRegion
    {
        public string? CountryRegionCode { get; set; }
        public string? Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}