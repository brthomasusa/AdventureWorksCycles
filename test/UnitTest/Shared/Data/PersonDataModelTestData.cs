using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;

namespace AWC.UnitTest.Shared.Data
{
    public static class PersonDataModelTestData
    {
        public static PersonDataModel GetPersonDataModel()
        {
            PersonDataModel person = new()
            {
                BusinessEntityID = 16,
                PersonType = "EM",
                NameStyle = false,
                Title = null,
                FirstName = "David",
                MiddleName = "M",
                LastName = "Bradley",
                Suffix = null,
                EmailPromotion = 1,
                Employee = new()
                {
                    BusinessEntityID = 16,
                    ManagerID = 1,
                    NationalIDNumber = "24756624",
                    LoginID = @"adventure-works\david0",
                    JobTitle = "Marketing Manager",
                    BirthDate = new DateTime(1975, 3, 19),
                    MaritalStatus = "S",
                    Gender = "M",
                    HireDate = new DateTime(2007, 12, 20),
                    SalariedFlag = true,
                    VacationHours = 40,
                    SickLeaveHours = 40,
                    DepartmentHistories = new()
                        {
                            new EmployeeDepartmentHistory() { BusinessEntityID = 16, DepartmentID = 5, ShiftID = 1, StartDate = new DateTime(2007, 12, 20), EndDate = new DateTime(2009, 7, 14) },
                            new EmployeeDepartmentHistory() { BusinessEntityID = 16, DepartmentID = 4, ShiftID = 1, StartDate = new DateTime(2009, 7, 15) }
                        },
                    PayHistories = new()
                        {
                            new EmployeePayHistory() { BusinessEntityID = 16, RateChangeDate = new DateTime(2007, 12, 20), Rate = 24.00M, PayFrequency = 2 },
                            new EmployeePayHistory() { BusinessEntityID = 16, RateChangeDate = new DateTime(2009, 7, 15), Rate = 28.75M, PayFrequency = 2 },
                            new EmployeePayHistory() { BusinessEntityID = 16, RateChangeDate = new DateTime(2012, 4, 30), Rate = 37.50M, PayFrequency = 2 }
                        }
                },
                Password = new() { BusinessEntityID = 16, PasswordHash = "oaeJoTn5hbyNfemp2qzIpGTP5uNle8NRPki9Ur3Znl8=", PasswordSalt = "CTdtN+Q=" },
                EmailAddresses = new() { new EmailAddress() { BusinessEntityID = 16, EmailAddressID = 16, MailAddress = "david0@adventure-works.com" } },
                Telephones = new() { new PersonPhone() { BusinessEntityID = 16, PhoneNumber = "913-555-0172", PhoneNumberTypeID = 3 } },
                BusinessEntityAddresses = new()
                    {
                        new BusinessEntityAddress()
                        {
                            BusinessEntityID = 16,
                            AddressID = 214,
                            Address = new Address(){ AddressID = 214, AddressLine1 = "3768 Door Way", AddressLine2 = null, City = "Redmond", StateProvinceID = 79, PostalCode = "98052"},
                            AddressTypeID = 2
                        }
                    }
            };

            return person;
        }
    }
}