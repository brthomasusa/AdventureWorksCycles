using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Core.Entities.Shared;
using AWC.Core.Entities.Shared.EntityIDs;
using AWC.Core.Enums;
using AWC.Shared.Commands.HumanResources;
using AWC.SharedKernel.Interfaces;
using AWC.SharedKernel.Utilities;
using MapsterMapper;

namespace AWC.Application.Mappings.HumanResources
{
    public sealed class CreateEmployeeCommandToEmployeeDomainModelMapper : ModelMapper<CreateEmployeeCommand, Employee>
    {
        private readonly IMapper _mapper;
        private Employee? _employee;
        private CreateEmployeeCommand? _command;

        public CreateEmployeeCommandToEmployeeDomainModelMapper(IMapper mapper)
            => _mapper = mapper;

        public override Result<Employee> Map(CreateEmployeeCommand command)
        {
            Result<Employee> result = _mapper.Map<Result<Employee>>(command);

            _employee = result.Value;
            _command = command;

            MapDepartmentHistories();
            MapPayHistories();
            MapAddresses();
            MapPersonEmailAddress();
            MapPersonPhones();

            return result.Value;
        }

        private void MapDepartmentHistories()
        {
            foreach (DepartmentHistoryCommand department in _command!.DepartmentHistories!)
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
            foreach (PayHistoryCommand pay in _command!.PayHistories!)
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
            Result<Address> result =
                _employee!.AddAddress
                (
                    new AddressID(_command!.AddressID),
                    AddressType.Home,
                    _command!.AddressLine1!,
                    _command!.AddressLine2,
                   _command!.City!,
                    _command!.StateProvinceID,
                    _command!.PostalCode!
                );

            if (result.IsFailure)
                throw new EmployeeMappingException(result.Error.Message);
        }


        private void MapPersonEmailAddress()
        {
            Result<PersonEmailAddress> result = _employee!.AddEmailAddress
            (
                    new PersonEmailAddressID(_command!.EmailAddressID),
                    _command!.EmailAddress
            );

            if (result.IsFailure)
                throw new EmployeeMappingException(result.Error.Message);
        }

        private void MapPersonPhones()
        {
            Result<PersonPhone> result = _employee!.AddPhoneNumber
            (
                    new PersonPhoneID(_command!.BusinessEntityID),
                    (PhoneNumberType)_command.PhoneNumberTypeID,
                    _command!.PhoneNumber!
            );

            if (result.IsFailure)
                throw new EmployeeMappingException(result.Error.Message);
        }

        public sealed class EmployeeMappingException : Exception
        {
            public EmployeeMappingException(string message)
                : base(message) { }
        }
    }
}