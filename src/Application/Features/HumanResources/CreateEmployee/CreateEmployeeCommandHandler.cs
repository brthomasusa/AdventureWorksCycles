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

        public async Task<Result<int>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Result<Employee> createEmployee = Employee.Create
            (
                request.BusinessEntityID,
                "EM",
                request.NameStyle == 0 ? NameStyleEnum.Western : NameStyleEnum.Eastern,
                request.Title,
                request.FirstName,
                request.LastName,
                request.MiddleName!,
                request.Suffix,
                request.ManagerID,
                request.NationalIDNumber,
                request.LoginID,
                request.JobTitle,
                DateOnly.FromDateTime(request.BirthDate),
                request.MaritalStatus,
                request.Gender,
                DateOnly.FromDateTime(request.HireDate),
                request.Salaried,
                request.VacationHours,
                request.SickLeaveHours,
                request.Active
            );

            if (createEmployee.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", createEmployee.Error.Message));

            Result<DepartmentHistory> createDepartmentHistory = createEmployee.Value.AddDepartmentHistory
            (
                createEmployee.Value.Id,
                request.DepartmentID,
                request.ShiftID,
                DateOnly.FromDateTime(request.HireDate),
                null
            );
            if (createDepartmentHistory.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", createDepartmentHistory.Error.Message));

            Result<PayHistory> createPayHistory = createEmployee.Value.AddPayHistory
            (
                createEmployee.Value.Id,
                request.HireDate,
                request.PayRate,
                (PayFrequencyEnum)request.PayFrequency
            );
            if (createPayHistory.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", createPayHistory.Error.Message));

            Result<Address> createAddress = createEmployee.Value.AddAddress
            (
                0,
                createEmployee.Value.Id,
                AddressTypeEnum.Home,
                request.AddressLine1,
                request.AddressLine2,
                request.City,
                request.StateProvinceID,
                "EM"
            );
            if (createAddress.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", createAddress.Error.Message));

            Result<PersonEmailAddress> createEmailAddress = createEmployee.Value.AddEmailAddress
            (
                createEmployee.Value.Id,
                0,
                request.EmailAddress
            );
            if (createEmailAddress.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", createEmailAddress.Error.Message));

            Result<PersonPhone> createPersonPhone = createEmployee.Value.AddPhoneNumber
            (
                createEmployee.Value.Id,
                (PhoneNumberTypeEnum)request.PhoneNumberTypeID,
                request.PhoneNumber
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