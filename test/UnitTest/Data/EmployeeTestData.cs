using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.Shared.Commands.HumanResources;


namespace AWC.UnitTest.Data
{
    public static class EmployeeTestData
    {
        public static CreateEmployeeCommand GetValidCreateEmployeeCommand()
        {
            return new(
                        BusinessEntityID: 0,
                        NameStyle: 0,
                        Title: "Mr.",
                        FirstName: "Johnny",
                        LastName: "Doe",
                        MiddleName: "J",
                        Suffix: null!,
                        JobTitle: "The Man",
                        PhoneNumber: "555-555-5555",
                        PhoneNumberTypeID: 2,
                        EmailAddress: "johnny@adventure-works.com",
                        EmailPromotion: 2,
                        NationalIDNumber: "13232145",
                        LoginID: @"adventure-works\johnny0",
                        AddressLine1: "123 street",
                        AddressLine2: "Apt 123",
                        City: "Somewhere",
                        StateProvinceID: 73,
                        PostalCode: "12345",
                        BirthDate: new DateTime(2003, 1, 17),
                        MaritalStatus: "M",
                        Gender: "M",
                        HireDate: new DateTime(2020, 1, 28),
                        Salaried: true,
                        VacationHours: 5,
                        SickLeaveHours: 1,
                        Active: true,
                        ManagerID: 1,
                        DepartmentHistories: new List<DepartmentHistoryCommand>()
                        {
                            new DepartmentHistoryCommand(){ BusinessEntityID = 0, DepartmentID = 16, ShiftID = 1, StartDate = new DateTime(2020, 1, 28) }
                        },
                        PayHistories: new List<PayHistoryCommand>()
                        {
                            new PayHistoryCommand() {BusinessEntityID = 0, RateChangeDate = new DateTime(2020, 1, 28), Rate = 20M, PayFrequency = 2}
                        }
                    );
        }

        public static CreateEmployeeCommand GetInvalidCreateEmployeeCommand_MultipleDepartmentHistories()
            => new(
                BusinessEntityID: 0,
                NameStyle: 0,
                Title: "Mr.",
                FirstName: "Johnny",
                LastName: "Doe",
                MiddleName: "J",
                Suffix: null!,
                JobTitle: "The Man",
                PhoneNumber: "555-555-5555",
                PhoneNumberTypeID: 2,
                EmailAddress: "johnny@adventure-works.com",
                EmailPromotion: 2,
                NationalIDNumber: "13232145",
                LoginID: @"adventure-works\johnny0",
                AddressLine1: "123 street",
                AddressLine2: "Apt 123",
                City: "Somewhere",
                StateProvinceID: 73,
                PostalCode: "12345",
                BirthDate: new DateTime(2003, 1, 17),
                MaritalStatus: "M",
                Gender: "M",
                HireDate: new DateTime(2020, 1, 28),
                Salaried: true,
                VacationHours: 5,
                SickLeaveHours: 1,
                Active: true,
                ManagerID: 1,
                DepartmentHistories: new List<DepartmentHistoryCommand>()
                {
                    new DepartmentHistoryCommand(){ BusinessEntityID = 0, DepartmentID = 16, ShiftID = 1, StartDate = new DateTime(2020, 1, 28), EndDate = new DateTime(2020, 1, 27) },
                    new DepartmentHistoryCommand(){ BusinessEntityID = 0, DepartmentID = 15, ShiftID = 1, StartDate = new DateTime(2021, 1, 28) }
                },
                PayHistories: new List<PayHistoryCommand>()
                {
                    new PayHistoryCommand() {BusinessEntityID = 0, RateChangeDate = new DateTime(2020, 1, 28), Rate = 20M, PayFrequency = 2}
                }
            );

        public static CreateEmployeeCommand GetInvalidCreateEmployeeCommand_EmptyDepartmentHistories()
            => new(
                BusinessEntityID: 0,
                NameStyle: 0,
                Title: "Mr.",
                FirstName: "Johnny",
                LastName: "Doe",
                MiddleName: "J",
                Suffix: null!,
                JobTitle: "The Man",
                PhoneNumber: "555-555-5555",
                PhoneNumberTypeID: 2,
                EmailAddress: "johnny@adventure-works.com",
                EmailPromotion: 2,
                NationalIDNumber: "13232145",
                LoginID: @"adventure-works\johnny0",
                AddressLine1: "123 street",
                AddressLine2: "Apt 123",
                City: "Somewhere",
                StateProvinceID: 73,
                PostalCode: "12345",
                BirthDate: new DateTime(2003, 1, 17),
                MaritalStatus: "M",
                Gender: "M",
                HireDate: new DateTime(2020, 1, 28),
                Salaried: true,
                VacationHours: 5,
                SickLeaveHours: 1,
                Active: true,
                ManagerID: 1,
                DepartmentHistories: new List<DepartmentHistoryCommand>() { },
                PayHistories: new List<PayHistoryCommand>()
                {
                    new PayHistoryCommand() {BusinessEntityID = 0, RateChangeDate = new DateTime(2020, 1, 28), Rate = 20M, PayFrequency = 2}
                }
            );

        public static CreateEmployeeCommand GetInvalidCreateEmployeeCommand_EmptyPayHistories()
            => new(
                BusinessEntityID: 0,
                NameStyle: 0,
                Title: "Mr.",
                FirstName: "Johnny",
                LastName: "Doe",
                MiddleName: "J",
                Suffix: null!,
                JobTitle: "The Man",
                PhoneNumber: "555-555-5555",
                PhoneNumberTypeID: 2,
                EmailAddress: "johnny@adventure-works.com",
                EmailPromotion: 2,
                NationalIDNumber: "13232145",
                LoginID: @"adventure-works\johnny0",
                AddressLine1: "123 street",
                AddressLine2: "Apt 123",
                City: "Somewhere",
                StateProvinceID: 73,
                PostalCode: "12345",
                BirthDate: new DateTime(2003, 1, 17),
                MaritalStatus: "M",
                Gender: "M",
                HireDate: new DateTime(2020, 1, 28),
                Salaried: true,
                VacationHours: 5,
                SickLeaveHours: 1,
                Active: true,
                ManagerID: 1,
                DepartmentHistories: new List<DepartmentHistoryCommand>()
                {
                    new DepartmentHistoryCommand(){ BusinessEntityID = 0, DepartmentID = 15, ShiftID = 1, StartDate = new DateTime(2020, 1, 28) }
                },
                PayHistories: new List<PayHistoryCommand>() { }
            );


        public static CreateEmployeeCommand GetInvalidCreateEmployeeCommand_MultiplePayHistories()
            => new(
                BusinessEntityID: 0,
                NameStyle: 0,
                Title: "Mr.",
                FirstName: "Johnny",
                LastName: "Doe",
                MiddleName: "J",
                Suffix: null!,
                JobTitle: "The Man",
                PhoneNumber: "555-555-5555",
                PhoneNumberTypeID: 2,
                EmailAddress: "johnny@adventure-works.com",
                EmailPromotion: 2,
                NationalIDNumber: "13232145",
                LoginID: @"adventure-works\johnny0",
                AddressLine1: "123 street",
                AddressLine2: "Apt 123",
                City: "Somewhere",
                StateProvinceID: 73,
                PostalCode: "12345",
                BirthDate: new DateTime(2003, 1, 17),
                MaritalStatus: "M",
                Gender: "M",
                HireDate: new DateTime(2020, 1, 28),
                Salaried: true,
                VacationHours: 5,
                SickLeaveHours: 1,
                Active: true,
                ManagerID: 1,
                DepartmentHistories: new List<DepartmentHistoryCommand>()
                {
                    new DepartmentHistoryCommand(){ BusinessEntityID = 0, DepartmentID = 16, ShiftID = 1, StartDate = new DateTime(2020, 1, 28) }
                },
                PayHistories: new List<PayHistoryCommand>()
                {
                    new PayHistoryCommand() {BusinessEntityID = 0, RateChangeDate = new DateTime(2020, 1, 28), Rate = 20M, PayFrequency = 2},
                    new PayHistoryCommand() {BusinessEntityID = 0, RateChangeDate = new DateTime(2021, 1, 28), Rate = 25M, PayFrequency = 2}
                }
            );

        public static CreateEmployeeCommand GetInvalidCreateEmployeeCommand_DeptStartDateNotEqualToHireDate()
            => new(
                BusinessEntityID: 0,
                NameStyle: 0,
                Title: "Mr.",
                FirstName: "Johnny",
                LastName: "Doe",
                MiddleName: "J",
                Suffix: null!,
                JobTitle: "The Man",
                PhoneNumber: "555-555-5555",
                PhoneNumberTypeID: 2,
                EmailAddress: "johnny@adventure-works.com",
                EmailPromotion: 2,
                NationalIDNumber: "13232145",
                LoginID: @"adventure-works\johnny0",
                AddressLine1: "123 street",
                AddressLine2: "Apt 123",
                City: "Somewhere",
                StateProvinceID: 73,
                PostalCode: "12345",
                BirthDate: new DateTime(2003, 1, 17),
                MaritalStatus: "M",
                Gender: "M",
                HireDate: new DateTime(2020, 1, 28),
                Salaried: true,
                VacationHours: 5,
                SickLeaveHours: 1,
                Active: true,
                ManagerID: 1,
                DepartmentHistories: new List<DepartmentHistoryCommand>()
                {
                    new DepartmentHistoryCommand(){ BusinessEntityID = 0, DepartmentID = 16, ShiftID = 1, StartDate = new DateTime(2020, 2, 28) }
                },
                PayHistories: new List<PayHistoryCommand>()
                {
                    new PayHistoryCommand() {BusinessEntityID = 0, RateChangeDate = new DateTime(2020, 1, 28), Rate = 20M, PayFrequency = 2}
                }
            );

        public static CreateEmployeeCommand GetInvalidCreateEmployeeCommand_PayHistoryPayRateChangeDateNotEqualToHireDate()
            => new(
                BusinessEntityID: 0,
                NameStyle: 0,
                Title: "Mr.",
                FirstName: "Johnny",
                LastName: "Doe",
                MiddleName: "J",
                Suffix: null!,
                JobTitle: "The Man",
                PhoneNumber: "555-555-5555",
                PhoneNumberTypeID: 2,
                EmailAddress: "johnny@adventure-works.com",
                EmailPromotion: 2,
                NationalIDNumber: "13232145",
                LoginID: @"adventure-works\johnny0",
                AddressLine1: "123 street",
                AddressLine2: "Apt 123",
                City: "Somewhere",
                StateProvinceID: 73,
                PostalCode: "12345",
                BirthDate: new DateTime(2003, 1, 17),
                MaritalStatus: "M",
                Gender: "M",
                HireDate: new DateTime(2020, 1, 28),
                Salaried: true,
                VacationHours: 5,
                SickLeaveHours: 1,
                Active: true,
                ManagerID: 1,
                DepartmentHistories: new List<DepartmentHistoryCommand>()
                {
                    new DepartmentHistoryCommand(){ BusinessEntityID = 0, DepartmentID = 16, ShiftID = 1, StartDate = new DateTime(2020, 1, 28) }
                },
                PayHistories: new List<PayHistoryCommand>()
                {
                    new PayHistoryCommand() {BusinessEntityID = 0, RateChangeDate = new DateTime(2020, 2, 28), Rate = 20M, PayFrequency = 2}
                }
            );

        public static UpdateEmployeeCommand GetUpdateEmployeeCommand_ValidData()
            => new(
                BusinessEntityID: 273,
                NameStyle: 0,
                Title: "Mr.",
                FirstName: "Johnny",
                LastName: "Doe",
                MiddleName: "J",
                Suffix: null,
                JobTitle: "The Man",
                PhoneNumber: "555-555-5555",
                PhoneNumberTypeID: 2,
                EmailAddress: "johnny@adventure-works.com",
                EmailPromotion: 2,
                NationalIDNumber: "13232145",
                LoginID: @"adventure-works\johnny0",
                AddressLine1: "123 street",
                AddressLine2: "Apt 123",
                City: "Somewhere",
                StateProvinceID: 73,
                PostalCode: "12345",
                BirthDate: new DateTime(2003, 1, 17),
                MaritalStatus: "M",
                Gender: "M",
                HireDate: new DateTime(2020, 1, 28),
                Salaried: true,
                VacationHours: 5,
                SickLeaveHours: 1,
                Active: true,
                ManagerID: 1,
                DepartmentHistories: new List<DepartmentHistoryCommand>()
                {
                    new DepartmentHistoryCommand(){ BusinessEntityID = 273, DepartmentID = 16, ShiftID = 1, StartDate = new DateTime(2020, 1, 28) }
                },
                PayHistories: new List<PayHistoryCommand>()
                {
                    new PayHistoryCommand() {BusinessEntityID = 273, RateChangeDate = new DateTime(2020, 1, 28), Rate = 20M, PayFrequency = 2}
                }
            );

        public static BusinessEntity GetBusinessEntity()
            => new()
            {
                BusinessEntityID = 0,
                PersonModel = new()
                {
                    PersonType = "EM",
                    NameStyle = false,
                    Title = "Mr.",
                    FirstName = "Johnny",
                    MiddleName = "D",
                    LastName = "Doe",
                    Suffix = "Jr.",
                    EmailPromotion = 2,
                    Employee = new EmployeeDataModel()
                    {
                        NationalIDNumber = "123797967",
                        LoginID = @"adventure-works\johnny01",
                        JobTitle = "Vice President At Large",
                        BirthDate = new DateTime(1971, 8, 1),
                        MaritalStatus = "M",
                        Gender = "M",
                        HireDate = new DateTime(2008, 1, 31),
                        SalariedFlag = true,
                        VacationHours = 1,
                        SickLeaveHours = 20,
                        CurrentFlag = true
                    },
                    EmailAddresses = new List<EmailAddress>()
                    {
                        new EmailAddress
                        {
                            MailAddress = "johnnydoe@adventureworks.com"
                        }
                    },
                    Telephones = new List<PersonPhone>()
                    {
                        new PersonPhone { PhoneNumber = "214-555-4567", PhoneNumberTypeID = 1},
                        new PersonPhone { PhoneNumber = "972-555-1234", PhoneNumberTypeID = 2},
                        new PersonPhone { PhoneNumber = "469-555-4567", PhoneNumberTypeID = 3}
                    }
                }
            };
    }
}