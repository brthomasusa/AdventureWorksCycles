namespace AWC.Infrastructure.Persistence.DataModels.Person
{
    public class Password
    {
        public int BusinessEntityID { get; set; }
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }
        public Guid RowGuid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}