using AWC.Application.Interfaces.Messaging;

namespace AWC.Application.Features.HumanResources.CreateEmployee
{
    public sealed record CreateEmployeeCommand
    (
            int EmployeeID,
            string PersonType,
            bool NameStyle,
            string? Title,
            string FirstName,
            string LastName,
            string? MiddleName,
            string? Suffix,
            int EmailPromotion,
            int ManagerID,
            string NationalID,
            string Login,
            string JobTitle,
            DateTime BirthDate,
            string MaritalStatus,
            string Gender,
            DateTime HireDate,
            bool Salaried,
            int Vacation,
            int SickLeave,
            bool Active,
            decimal PayRate,
            int PayFrequency,
            int DepartmentID,
            int ShiftID,
            int AddressType,
            string AddressLine1,
            string AddressLine2,
            string City,
            int StateCode,
            string PostalCode,
            string EmailAddress,
            string PhoneNumber,
            int PhoneNumberType
    ) : ICommand<int>;
}