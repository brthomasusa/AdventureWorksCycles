using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Commands.HumanResources;

namespace AWC.Application.Features.HumanResources.CreateEmployee;
public sealed record CreateEmployeeCommand
(
    int BusinessEntityID,
    int NameStyle,
    string? Title,
    string FirstName,
    string LastName,
    string? MiddleName,
    string? Suffix,
    string JobTitle,
    string PhoneNumber,
    int PhoneNumberTypeID,
    string EmailAddress,
    int EmailPromotion,
    string NationalIDNumber,
    string LoginID,
    string AddressLine1,
    string AddressLine2,
    string City,
    int StateProvinceID,
    string PostalCode,
    DateTime BirthDate,
    string MaritalStatus,
    string Gender,
    DateTime HireDate,
    bool Salaried,
    int VacationHours,
    int SickLeaveHours,
    decimal PayRate,
    int PayFrequency,
    bool Active,
    int ManagerID,
    int DepartmentID,
    int ShiftID,
    List<DepartmentHistoryCommand>? DepartmentHistories,
    List<PayHistoryCommand>? PayHistories
) : ICommand<int>;
