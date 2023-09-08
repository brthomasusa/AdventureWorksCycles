namespace AWC.Shared.Queries.Lookups.HumanResources
{
    public static class SimpleLookups
    {
        public static IEnumerable<MaritalStatuses> GetMaritalStatuses()
            => new MaritalStatuses[] {
                new MaritalStatuses() { Id = "M" , Status = "Married"},
                new MaritalStatuses() { Id = "S" , Status = "Single"}
            };

        public static IEnumerable<Gender> GetGenders()
            => new Gender[] {
                new Gender() { Id = "M" , Name = "Male"},
                new Gender() { Id = "F" , Name = "Female"}
            };

        public static IEnumerable<NameStyle> GetNameStyles()
            => new NameStyle[]
            {
                new NameStyle() { Id = 0, Name = "Western"},
                new NameStyle() { Id = 1, Name = "Eastern"}
            };

        public static IEnumerable<EmailPromotionPreference> GetEmailPromotionPreference()
            => new EmailPromotionPreference[]
            {
                new EmailPromotionPreference() { Id = 0, PromotionPreference = "Does not wish to receive email promotions"},
                new EmailPromotionPreference() { Id = 1, PromotionPreference = "From AdventureWorks only"},
                new EmailPromotionPreference() { Id = 2, PromotionPreference = "From AdventureWorks and selected partners"}
            };

        public static IEnumerable<PayFrequency> GetPayFrequencies()
            => new PayFrequency[]
            {
                new PayFrequency() { Id = 1, Name = "Monthly"},
                new PayFrequency() { Id = 2, Name = "Biweekly"}
            };

        public static IEnumerable<PhoneNumberType> GetPhoneNumberTypes()
            => new PhoneNumberType[]
            {
                new PhoneNumberType() { Id = 1, Name = "Cell"},
                new PhoneNumberType() { Id = 2, Name = "Home"},
                new PhoneNumberType() { Id = 3, Name = "Work"}
            };

        public static IEnumerable<SalariedFlag> GetSalariedFlags()
            => new SalariedFlag[]
            {
                new SalariedFlag() { Id = false, Name = "Hourly"},
                new SalariedFlag() { Id = true, Name = "Salaried"}
            };

    }

    public sealed class NameStyle
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public sealed class MaritalStatuses
    {
        public string? Id { get; set; }
        public string? Status { get; set; }
    }

    public sealed class Gender
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }

    public sealed class EmailPromotionPreference
    {
        public int Id { get; set; }
        public string? PromotionPreference { get; set; }
    }

    public sealed class PayFrequency
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public sealed class PhoneNumberType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public sealed class SalariedFlag
    {
        public bool Id { get; set; }
        public string? Name { get; set; }
    }
}