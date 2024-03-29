namespace AWC.Shared.Queries.HumanResources
{
    public sealed class EmployeeDetails
    {
        public int BusinessEntityID { get; set; }
        public string? NameStyle { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
        public string? JobTitle { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhoneNumberType { get; set; }
        public string? EmailAddress { get; set; }
        public string? EmailPromotion { get; set; }
        public string? NationalIDNumber { get; set; }
        public string? LoginID { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? StateProvinceName { get; set; }
        public string? PostalCode { get; set; }
        public string? CountryRegionName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool Salaried { get; set; }
        public int VacationHours { get; set; }
        public int SickLeaveHours { get; set; }
        public decimal PayRate { get; set; }
        public string? PayFrequency { get; set; }
        public bool Active { get; set; }
        public string? ManagerName { get; set; }
        public string? Department { get; set; }
        public string? Shift { get; set; }
        public string? Address { get; set; }
        public List<DepartmentHistory>? DepartmentHistories { get; set; }
        public List<PayHistory>? PayHistories { get; set; }
    }
}