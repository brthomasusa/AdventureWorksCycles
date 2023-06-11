namespace AWC.Infrastructure.Persistence.DataModels.Person
{
    public sealed class PhoneNumberType
    {
        public int PhoneNumberTypeID { get; set; }
        public string? Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}