#pragma warning disable CS8604

using AWC.Core.Entities.HumanResources;
using AWC.Core.Enums;
using AWC.Infrastructure.Persistence.DataModels.Person;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public static class EmployeeMappingExtensions
    {
        public static void MapToPersonDataModel(this Employee employee, ref PersonDataModel person)
        {
            // Person
            person.PersonType = employee.PersonType;
            person.NameStyle = employee.NameStyle != NameStyle.Western;
            person.Title = employee.Title ?? null;
            person.FirstName = employee.Name.FirstName;
            person.MiddleName = employee.Name.MiddleName!;
            person.LastName = employee.Name.LastName;
            person.Suffix = employee.Suffix ?? null;
            person.EmailPromotion = (int)employee.EmailPromotions;

            // Address. This works because a person who is an employee is restricted to one address
            BusinessEntityAddress bea = person.BusinessEntityAddresses.FirstOrDefault()!;

            bea.Address!.AddressLine1 = employee.Addresses.FirstOrDefault()!.Location.AddressLine1;
            bea.Address!.AddressLine2 = employee.Addresses.FirstOrDefault()!.Location.AddressLine2;
            bea.Address!.City = employee.Addresses.FirstOrDefault()!.Location.City;
            bea.Address!.StateProvinceID = employee.Addresses.FirstOrDefault()!.Location.StateProvinceID;
            bea.Address!.PostalCode = employee.Addresses.FirstOrDefault()!.Location.PostalCode;

            // Email Address. This works because a person who is an employee is restricted to one email address
            person.EmailAddresses.FirstOrDefault()!.MailAddress = employee.EmailAddresses.FirstOrDefault()!.EmailAddress;

            // Employee
            person.Employee!.NationalIDNumber = employee.NationalIDNumber;
            person.Employee!.LoginID = employee.LoginID;
            person.Employee!.JobTitle = employee.JobTitle;
            person.Employee!.BirthDate = employee.BirthDate.Value.ToDateTime(new TimeOnly());
            person.Employee!.MaritalStatus = employee.MaritalStatus;
            person.Employee!.Gender = employee.Gender;
            person.Employee!.HireDate = employee.HireDate.Value.ToDateTime(new TimeOnly());
            person.Employee!.SalariedFlag = employee.IsSalaried;
            person.Employee!.VacationHours = employee.VacationHours;
            person.Employee!.SickLeaveHours = employee.SickLeaveHours;
            person.Employee!.CurrentFlag = employee.IsActive;
        }
    }

    public sealed class EmployeeMappingException : Exception
    {
        public EmployeeMappingException(string message)
            : base(message) { }
    }
}