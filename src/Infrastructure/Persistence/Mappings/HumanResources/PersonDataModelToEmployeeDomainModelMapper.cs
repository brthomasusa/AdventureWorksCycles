using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Core.Entities.Shared;
using AWC.Core.Entities.Shared.EntityIDs;
using AWC.Core.Enums;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.SharedKernel.Interfaces;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public sealed class PersonDataModelToEmployeeDomainModelMapper : ModelMapper<PersonDataModel, Employee>
    {
        private Employee? _employee;
        private PersonDataModel? _person;

        public override Result<Employee> Map(AWC.Infrastructure.Persistence.DataModels.Person.PersonDataModel dataModel)
        {
            try
            {
                Result<Employee> result = Employee.Create
                (
                    new EmployeeID(dataModel.BusinessEntityID),
                    dataModel.PersonType!,
                    dataModel.NameStyle ? NameStyle.Eastern : NameStyle.Western,
                    dataModel.Title,
                    dataModel.FirstName!,
                    dataModel.LastName!,
                    dataModel.MiddleName!,
                    dataModel.Suffix,
                    new EmployeeID(dataModel.Employee!.ManagerID),
                    dataModel.Employee!.NationalIDNumber!,
                    dataModel.Employee!.LoginID!,
                    dataModel.Employee!.JobTitle!,
                    DateOnly.FromDateTime(dataModel.Employee!.BirthDate),
                    dataModel.Employee!.MaritalStatus!,
                    dataModel.Employee!.Gender!,
                    DateOnly.FromDateTime(dataModel.Employee!.HireDate),
                    dataModel.Employee!.SalariedFlag,
                    dataModel.Employee!.VacationHours,
                    dataModel.Employee!.SickLeaveHours,
                    dataModel.Employee!.CurrentFlag
                );

                _employee = result.Value;
                _person = dataModel;

                MapDepartmentHistories();
                MapPayHistories();
                MapAddresses();
                MapEmailAddresses();
                MapPersonPhones();

                return result.Value;
            }
            catch (Exception ex)
            {
                return Result<Employee>.Failure<Employee>(new Error("EmployeeWriteRepository.GetByIdAsync", Helpers.GetExceptionMessage(ex)));
            }
        }

        private void MapDepartmentHistories()
        {
            foreach (EmployeeDepartmentHistory department in _person!.Employee!.DepartmentHistories)
            {
                Result<DepartmentHistory> result = _employee!.AddDepartmentHistory
                (
                    new DepartmentHistoryID(department.BusinessEntityID),
                    new DepartmentID(department.DepartmentID),
                    new ShiftID(department.ShiftID),
                    DateOnly.FromDateTime(department.StartDate),
                    department.EndDate is null ? null : DateOnly.FromDateTime((DateTime)department.EndDate!)
                );

                if (result.IsFailure)
                    throw new EmployeeMappingException(result.Error.Message);
            }
        }

        private void MapPayHistories()
        {
            foreach (EmployeePayHistory pay in _person!.Employee!.PayHistories)
            {
                Result<PayHistory> result = _employee!.AddPayHistory(
                    new PayHistoryID(pay.BusinessEntityID),
                    pay.RateChangeDate,
                    pay.Rate,
                    (PayFrequency)pay.PayFrequency
                );

                if (result.IsFailure)
                    throw new EmployeeMappingException(result.Error.Message);
            }
        }

        private void MapAddresses()
        {
            foreach (BusinessEntityAddress bea in _person!.BusinessEntityAddresses)
            {
                Result<Core.Entities.Shared.Address> result =
                    _employee!.AddAddress
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
        }

        private void MapEmailAddresses()
        {
            foreach (EmailAddress email in _person!.EmailAddresses)
            {
                Result<PersonEmailAddress> result =
                    _employee!.AddEmailAddress
                    (
                        new PersonEmailAddressID(email.EmailAddressID),
                        email.MailAddress!
                    );

                if (result.IsFailure)
                    throw new EmployeeMappingException(result.Error.Message);
            }
        }

        private void MapPersonPhones()
        {
            foreach (DataModels.Person.PersonPhone phone in _person!.Telephones)
            {
                Result<Core.Entities.Shared.PersonPhone> result = _employee!.AddPhoneNumber
                (
                        new PersonPhoneID(phone.BusinessEntityID),
                        (Core.Enums.PhoneNumberType)phone.PhoneNumberTypeID,
                        phone.PhoneNumber!
                );

                if (result.IsFailure)
                    throw new EmployeeMappingException(result.Error.Message);
            }
        }

        public sealed class EmployeeMappingException : Exception
        {
            public EmployeeMappingException(string message)
                : base(message) { }
        }
    }
}