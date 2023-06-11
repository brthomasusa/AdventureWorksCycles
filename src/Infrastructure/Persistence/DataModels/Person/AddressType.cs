namespace AWC.Infrastructure.Persistence.DataModels.Person
{
    public sealed class AddressType
    {
        public int AddressTypeID { get; set; }
        public string? Name { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}