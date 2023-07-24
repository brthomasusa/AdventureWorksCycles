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
            Result<Employee> getEmployee = Employee.Create
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

            if (getEmployee.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", getEmployee.Error.Message));

            Result<DepartmentHistory> deptResult = getEmployee.Value.AddDepartmentHistory
            (
                getEmployee.Value.Id,
                request.ShiftID,
                DateOnly.FromDateTime(request.HireDate),
                null
            );
            if (deptResult.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", deptResult.Error.Message));

            Result<PayHistory> payResult = getEmployee.Value.AddPayHistory
            (
                getEmployee.Value.Id,
                request.HireDate,
                request.PayRate,
                (PayFrequencyEnum)request.PayFrequency
            );
            if (payResult.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", payResult.Error.Message));

            Result<Address> addrResult = getEmployee.Value.AddAddress
            (
                0,
                getEmployee.Value.Id,
                AddressTypeEnum.Home,
                request.AddressLine1,
                request.AddressLine2,
                request.City,
                request.StateProvinceID,
                "EM"
            );
            if (addrResult.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", addrResult.Error.Message));

            Result<PersonEmailAddress> emailResult = getEmployee.Value.AddEmailAddress
            (
                getEmployee.Value.Id,
                0,
                request.EmailAddress
            );
            if (emailResult.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", emailResult.Error.Message));

            Result<PersonPhone> phoneResult = getEmployee.Value.AddPhoneNumber
            (
                getEmployee.Value.Id,
                (PhoneNumberTypeEnum)request.PhoneNumberTypeID,
                request.PhoneNumber
            );
            if (phoneResult.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", phoneResult.Error.Message));

            Result<int> insertDbResult = await _repo.EmployeeAggregateRepository.InsertAsync(getEmployee.Value);
            if (!insertDbResult.IsSuccess)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", insertDbResult.Error.Message));

            return insertDbResult;
        }
    }
}