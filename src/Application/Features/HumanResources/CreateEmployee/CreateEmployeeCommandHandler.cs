using AWC.Application.Interfaces.Messaging;
using AWC.Core.HumanResources;
using AWC.Core.Shared;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.CreateEmployee
{
    public sealed class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, int>
    {
        private readonly IWriteRepositoryManager _repo;

        public CreateEmployeeCommandHandler(IWriteRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<int>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            Result<Employee> createEmployee = Employee.Create
            (
                command.BusinessEntityID,
                "EM",
                command.NameStyle == 0 ? NameStyleEnum.Western : NameStyleEnum.Eastern,
                command.Title,
                command.FirstName,
                command.LastName,
                command.MiddleName!,
                command.Suffix,
                command.ManagerID,
                command.NationalIDNumber,
                command.LoginID,
                command.JobTitle,
                DateOnly.FromDateTime(command.BirthDate),
                command.MaritalStatus,
                command.Gender,
                DateOnly.FromDateTime(command.HireDate),
                command.Salaried,
                command.VacationHours,
                command.SickLeaveHours,
                command.Active
            );

            if (createEmployee.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", createEmployee.Error.Message));

            command.DepartmentHistories!.ForEach(cmd => createEmployee.Value.AddDepartmentHistory
            (
                cmd.BusinessEntityID,
                cmd.DepartmentID,
                cmd.ShiftID,
                DateOnly.FromDateTime(cmd.StartDate),
                null
            ));

            command.PayHistories!.ForEach(cmd => createEmployee.Value.AddPayHistory
            (
                cmd.BusinessEntityID,
                cmd.RateChangeDate,
                cmd.Rate,
                (PayFrequencyEnum)cmd.PayFrequency
            ));

            Result<Address> createAddress = createEmployee.Value.AddAddress
            (
                0,
                createEmployee.Value.Id,
                AddressTypeEnum.Home,
                command.AddressLine1,
                command.AddressLine2,
                command.City,
                command.StateProvinceID,
                "EM"
            );
            if (createAddress.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", createAddress.Error.Message));

            Result<PersonEmailAddress> createEmailAddress = createEmployee.Value.AddEmailAddress
            (
                createEmployee.Value.Id,
                0,
                command.EmailAddress
            );
            if (createEmailAddress.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", createEmailAddress.Error.Message));

            Result<PersonPhone> createPersonPhone = createEmployee.Value.AddPhoneNumber
            (
                createEmployee.Value.Id,
                (PhoneNumberTypeEnum)command.PhoneNumberTypeID,
                command.PhoneNumber
            );
            if (createPersonPhone.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", createPersonPhone.Error.Message));

            Result<int> insertDbResult = await _repo.EmployeeAggregateRepository.InsertAsync(createEmployee.Value);
            if (insertDbResult.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", insertDbResult.Error.Message));

            return insertDbResult;
        }
    }
}