#pragma warning disable CS8604

using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Core.Entities.Shared;
using AWC.Core.Entities.Shared.EntityIDs;
using AWC.Core.Enums;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public static class EmployeeMappingExtensions
    {
        public static Result<Employee> MapToEmployeeDomainModel(this PersonDataModel person)
        {
            return Employee.Create
            (
                new EmployeeID(person!.BusinessEntityID),
                person!.PersonType!,
                person!.NameStyle ? NameStyle.Eastern : NameStyle.Western,
                person!.Title,
                person!.FirstName!,
                person!.LastName!,
                person!.MiddleName!,
                person!.Suffix,
                new EmployeeID(person!.Employee!.ManagerID),
                person!.Employee!.NationalIDNumber!,
                person!.Employee!.LoginID!,
                person!.Employee!.JobTitle!,
                DateOnly.FromDateTime(person!.Employee!.BirthDate),
                person!.Employee!.MaritalStatus!,
                person!.Employee!.Gender!,
                DateOnly.FromDateTime(person!.Employee!.HireDate),
                person!.Employee!.SalariedFlag,
                person!.Employee!.VacationHours,
                person!.Employee!.SickLeaveHours,
                person!.Employee!.CurrentFlag
            );
        }

        public static Employee MapDepartmentHistories(this PersonDataModel person, ref Employee employee)
        {
            foreach (EmployeeDepartmentHistory department in person!.Employee!.DepartmentHistories)
            {
                Result<DepartmentHistory> result = employee.AddDepartmentHistory
                (
                    new DepartmentHistoryID(department.BusinessEntityID),
                    new DepartmentID(department.DepartmentID),
                    new ShiftID(department.ShiftID),
                    DateOnly.FromDateTime(department.StartDate),
                    DateOnly.FromDateTime((DateTime)department.EndDate!)
                );

                if (result.IsFailure)
                    throw new EmployeeMappingException(result.Error.Message);
            }

            return employee;
        }

        public static Employee MapPayHistories(this PersonDataModel person, ref Employee employee)
        {
            foreach (EmployeePayHistory pay in person!.Employee!.PayHistories)
            {
                Result<PayHistory> result = employee.AddPayHistory(
                    new PayHistoryID(pay.BusinessEntityID),
                    pay.RateChangeDate,
                    pay.Rate,
                    (PayFrequency)pay.PayFrequency
                );

                if (result.IsFailure)
                    throw new EmployeeMappingException(result.Error.Message);
            }

            return employee;
        }

        public static Employee MapAddresses(this PersonDataModel person, ref Employee employee)
        {
            foreach (BusinessEntityAddress bea in person!.BusinessEntityAddresses)
            {
                Result<Core.Entities.Shared.Address> result =
                    employee.AddAddress
                    (
                        new AddressID(bea.AddressID),
                        (Core.Enums.AddressType)bea.AddressTypeID,
                        bea.Address!.AddressLine1!,
                        bea.Address.AddressLine2,
                        bea.Address!.City!,
                        bea.Address.StateProvinceID,
                        bea.Address!.PostalCode!
                    );

                if (result.IsFailure)
                    throw new EmployeeMappingException(result.Error.Message);
            }

            return employee;
        }

        public static Employee MapEmailAddresses(this PersonDataModel person, ref Employee employee)
        {
            foreach (EmailAddress email in person.EmailAddresses)
            {
                Result<PersonEmailAddress> result =
                    employee.AddEmailAddress
                    (
                        new PersonEmailAddressID(email.EmailAddressID),
                        email.MailAddress!
                    );

                if (result.IsFailure)
                    throw new EmployeeMappingException(result.Error.Message);
            }

            return employee;
        }

        public static Employee MapPersonPhones(this PersonDataModel person, ref Employee employee)
        {
            foreach (DataModels.Person.PersonPhone phone in person!.Telephones)
            {
                Result<Core.Entities.Shared.PersonPhone> result = employee.AddPhoneNumber
                (
                        new PersonPhoneID(phone.BusinessEntityID),
                        (Core.Enums.PhoneNumberType)phone.PhoneNumberTypeID,
                        phone.PhoneNumber!
                );

                if (result.IsFailure)
                    throw new EmployeeMappingException(result.Error.Message);
            }

            return employee;
        }

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