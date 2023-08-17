using AWC.Core.HumanResources;
using AWC.Core.Shared;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public static class EmployeeDataModelToDomainModel
    {
        public static Result<Employee> MapToEmployeeDomainObject(this PersonDataModel person)
        {
            Result<Employee> employeeDomainObject = MapToEmployee(person);

            if (employeeDomainObject.IsFailure)
                return Result<Employee>.Failure<Employee>(new Error("FromDataModelToDomainModel.MapToEmployeeDomainObject", employeeDomainObject.Error.Message));

            // Add dept histories to employee from person data model
            foreach (EmployeeDepartmentHistory department in person!.Employee!.DepartmentHistories)
            {
                Result<DepartmentHistory> result = employeeDomainObject.Value.AddDepartmentHistory
                (
                    department.BusinessEntityID,
                    department.DepartmentID,
                    department.ShiftID,
                    DateOnly.FromDateTime(department.StartDate),
                    department.EndDate
                );

                if (result.IsFailure)
                    return Result<Employee>.Failure<Employee>(GetError(result.Error.Message));
            }

            // Add pay histories to employee from person data model
            foreach (EmployeePayHistory pay in person!.Employee!.PayHistories)
            {
                Result<PayHistory> result = employeeDomainObject.Value.AddPayHistory(
                    pay.BusinessEntityID,
                    pay.RateChangeDate,
                    pay.Rate,
                    (PayFrequencyEnum)pay.PayFrequency
                );

                if (result.IsFailure)
                    return Result<Employee>.Failure<Employee>(GetError(result.Error.Message));
            }

            // Add addresses to employee from person data model
            if (person!.BusinessEntityAddresses.ToList().Any())
            {
                foreach (BusinessEntityAddress bea in person!.BusinessEntityAddresses)
                {
                    Result<Core.Shared.Address> result =
                        employeeDomainObject.Value.AddAddress
                        (
                            bea.AddressID,
                            bea.BusinessEntityID,
                            (AddressTypeEnum)bea.AddressTypeID,
                            bea.Address!.AddressLine1!,
                            bea.Address.AddressLine2,
                            bea.Address!.City!,
                            bea.Address.StateProvinceID,
                            bea.Address!.PostalCode!
                        );

                    if (result.IsFailure)
                        return Result<Employee>.Failure<Employee>(GetError(result.Error.Message));
                }
            }

            // Add email addresses to employee from person data model
            if (person.EmailAddresses.ToList().Any())
            {
                foreach (EmailAddress email in person.EmailAddresses)
                {
                    Result<PersonEmailAddress> result =
                        employeeDomainObject.Value.AddEmailAddress
                        (
                            email.BusinessEntityID,
                            email.EmailAddressID,
                            email.MailAddress!
                        );

                    if (result.IsFailure)
                        return Result<Employee>.Failure<Employee>(GetError(result.Error.Message));
                }
            }

            // Add telephones to employee from person data model
            if (person!.Telephones.ToList().Any())
            {
                foreach (DataModels.Person.PersonPhone phone in person!.Telephones)
                {
                    Result<Core.Shared.PersonPhone> result = employeeDomainObject.Value.AddPhoneNumber
                    (
                            phone.BusinessEntityID,
                            (PhoneNumberTypeEnum)phone.PhoneNumberTypeID,
                            phone.PhoneNumber!
                    );

                    if (result.IsFailure)
                        return Result<Employee>.Failure<Employee>(GetError(result.Error.Message));
                }
            }

            return employeeDomainObject;
        }

        private static Error GetError(string errMsg)
            => new Error("FromDataModelToDomainModel.MapToEmployeeDomainObject", errMsg);

        private static Result<Employee> MapToEmployee(PersonDataModel person)
            => Employee.Create
                (
                    person!.BusinessEntityID,
                    person!.PersonType!,
                    person!.NameStyle ? NameStyleEnum.Eastern : NameStyleEnum.Western,
                    person!.Title,
                    person!.FirstName!,
                    person!.LastName!,
                    person!.MiddleName!,
                    person!.Suffix,
                    person!.Employee!.ManagerID,
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
}