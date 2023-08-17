using AWC.Application.Features.HumanResources.Common;
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
            Result<Employee> employeeDomainObject = EmployeeDomainObjectBuilder.Build
            (
                command.BusinessEntityID,
                "EM",
                command.NameStyle == 0 ? NameStyleEnum.Western : NameStyleEnum.Eastern,
                command.Title,
                command.FirstName,
                command.MiddleName!,
                command.LastName,
                command.Suffix,
                command.ManagerID,
                command.JobTitle,
                command.PhoneNumber,
                PhoneNumberTypeEnum.Home,
                command.EmailAddress,
                command.EmailPromotion,
                command.NationalIDNumber,
                command.LoginID,
                command.AddressLine1,
                command.AddressLine2!,
                command.City,
                command.StateProvinceID,
                command.PostalCode,
                command.BirthDate,
                command.MaritalStatus,
                command.Gender,
                command.HireDate,
                command.Salaried,
                command.VacationHours,
                command.SickLeaveHours,
                command.Active,
                command.DepartmentHistories,
                command.PayHistories
            );

            if (employeeDomainObject.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", employeeDomainObject.Error.Message));

            Result<int> insertDbResult = await _repo.EmployeeAggregateRepository.InsertAsync(employeeDomainObject.Value);

            if (insertDbResult.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", insertDbResult.Error.Message));

            return insertDbResult;
        }
    }
}