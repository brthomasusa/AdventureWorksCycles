namespace AWC.Shared.Queries.Lookups.HumanResources
{
    public static class SimpleLookups
    {
        public static IEnumerable<MaritalStatuses> GetMaritalStatuses()
            => new MaritalStatuses[] {
                new MaritalStatuses() { Id = "M" , Status = "Married"},
                new MaritalStatuses() { Id = "S" , Status = "Single"}};

        public static IEnumerable<Gender> GetGenders()
            => new Gender[] {
                new Gender() { Id = "M" , Name = "Male"},
                new Gender() { Id = "F" , Name = "Female"}};

        public static IEnumerable<NameStyle> GetNameStyles()
            => new NameStyle[]
            {
                new NameStyle() { Id = 0, Name = "Western"},
                new NameStyle() { Id = 1, Name = "Eastern"}};


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
}