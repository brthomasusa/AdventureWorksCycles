using System.Linq;
using AWC.Core.HumanResources;
using AWC.Core.Shared;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public static class EmployeeDomainModelToDataModel
    {
        public static PersonDataModel MapToPersonDataModelForCreate(this Employee employee)
        {
            List<EmployeeDepartmentHistory> departmentHistories = new();
            List<EmployeePayHistory> payHistories = new();
            List<AWC.Infrastructure.Persistence.DataModels.Person.EmailAddress> emailAddresses = new();
            List<AWC.Infrastructure.Persistence.DataModels.Person.PersonPhone> personPhones = new();

            // DateOnly dateOnly = new(2021, 9, 16);

            employee.DepartmentHistories.ToList().ForEach(dept =>
                departmentHistories.Add(new EmployeeDepartmentHistory()
                {
                    BusinessEntityID = dept.Id,
                    DepartmentID = (short)dept.DepartmentID,
                    ShiftID = (byte)dept.ShiftID,
                    StartDate = dept.StartDate.ToDateTime(TimeOnly.MinValue)
                })
            );

            employee.PayHistories.ToList().ForEach(payHistory =>
                payHistories.Add(new EmployeePayHistory()
                {
                    BusinessEntityID = payHistory.Id,
                    RateChangeDate = payHistory.RateChangeDate,
                    Rate = payHistory.PayRate.Value.Amount,
                    PayFrequency = (byte)payHistory.PayFrequency
                })
            );

            employee.Telephones.ToList().ForEach(phone =>
                personPhones.Add(new AWC.Infrastructure.Persistence.DataModels.Person.PersonPhone()
                {
                    BusinessEntityID = phone.Id,
                    PhoneNumber = phone.Telephone,
                    PhoneNumberTypeID = ((int)Core.Shared.PhoneNumberType.Home)
                })
            );

            employee.EmailAddresses.ToList().ForEach(email =>
                emailAddresses.Add(new AWC.Infrastructure.Persistence.DataModels.Person.EmailAddress()
                {
                    BusinessEntityID = email.Id,
                    EmailAddressID = email.EmailAddressID,
                    MailAddress = email.EmailAddress
                })
            );

            PersonDataModel person = new()
            {
                PersonType = employee.PersonType,
                NameStyle = employee.NameStyle != NameStyle.Western,
                Title = employee.Title,
                FirstName = employee.Name.FirstName,
                MiddleName = employee.Name.MiddleName,
                LastName = employee.Name.LastName,
                Suffix = employee.Suffix,
                EmailPromotion = (int)employee.EmailPromotions,
                Employee = new EmployeeDataModel()
                {
                    NationalIDNumber = employee.NationalIDNumber,
                    LoginID = employee.LoginID,
                    JobTitle = employee.JobTitle,
                    BirthDate = employee.BirthDate.Value.ToDateTime(new TimeOnly()),
                    MaritalStatus = employee.MaritalStatus,
                    Gender = employee.Gender,
                    HireDate = employee.HireDate.Value.ToDateTime(new TimeOnly()),
                    SalariedFlag = employee.IsSalaried,
                    VacationHours = employee.VacationHours,
                    SickLeaveHours = employee.SickLeaveHours,
                    CurrentFlag = employee.IsActive,
                    DepartmentHistories = departmentHistories,
                    PayHistories = payHistories
                },
                EmailAddresses = emailAddresses,
                Telephones = personPhones
            };

            return person;
        }

        public static void MapToPersonDataModelForUpdate(this Employee employee, ref PersonDataModel person)
        {
            // Person
            person.PersonType = employee.PersonType;
            person.NameStyle = employee.NameStyle != NameStyle.Western;
            person.Title = employee.Title;
            person.FirstName = employee.Name.FirstName;
            person.MiddleName = employee.Name.MiddleName!;
            person.LastName = employee.Name.LastName;
            person.Suffix = employee.Suffix;
            person.EmailPromotion = (int)employee.EmailPromotions;

            // Address. This works because a person who is an employee is restricted to one address
            person.BusinessEntityAddresses.FirstOrDefault()!.Address!.AddressLine1 = employee.Addresses.FirstOrDefault()!.Location.AddressLine1;
            person.BusinessEntityAddresses.FirstOrDefault()!.Address!.AddressLine2 = employee.Addresses.FirstOrDefault()!.Location.AddressLine2;
            person.BusinessEntityAddresses.FirstOrDefault()!.Address!.City = employee.Addresses.FirstOrDefault()!.Location.City;
            person.BusinessEntityAddresses.FirstOrDefault()!.Address!.StateProvinceID = employee.Addresses.FirstOrDefault()!.Location.StateProvinceID;
            person.BusinessEntityAddresses.FirstOrDefault()!.Address!.PostalCode = employee.Addresses.FirstOrDefault()!.Location.Zipcode;

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

        /*
            The Employee class does not have an AddAddress method. It's base class Person has the AddAddress method.
            The Person class has a collection of BusinessEntityAddress instances; each one links the Person to one
            Address class. This extension method gets the actual addresses and embeds them directly in the 
            Person class. It's just easier to manipulate.
        */
        public static void MapDataModelAddressToDomainAddress(this BusinessEntityAddress businessEntityAddress, ref Employee employee)
            => employee.AddAddress(
                businessEntityAddress.AddressID,
                    businessEntityAddress.BusinessEntityID,
                    (Core.Shared.AddressType)businessEntityAddress.AddressTypeID,
                    businessEntityAddress.Address!.AddressLine1!,
                    businessEntityAddress.Address.AddressLine2,
                    businessEntityAddress.Address!.City!,
                    businessEntityAddress.Address.StateProvinceID,
                    businessEntityAddress.Address!.PostalCode!
                );
    }
}