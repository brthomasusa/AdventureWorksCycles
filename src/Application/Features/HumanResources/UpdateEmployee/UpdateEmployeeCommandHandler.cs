using AWC.Application.Features.HumanResources.Common;
using AWC.Application.Interfaces.Messaging;
using AWC.Core.HumanResources;
using AWC.Core.Shared;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Utilities;


namespace AWC.Application.Features.HumanResources.UpdateEmployee
{
    public sealed class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, int>
    {
        private const int RETURN_VALUE = 0;
        private readonly IWriteRepositoryManager _repo;

        public UpdateEmployeeCommandHandler(IWriteRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<int>> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            try
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

                Result<int> updateDbResult = await _repo.EmployeeAggregateRepository.Update(employeeDomainObject.Value);

                if (updateDbResult.IsFailure)
                    return Result<int>.Failure<int>(new Error("UpdateEmployeeCommandHandler.Handle", updateDbResult.Error.Message));

                return RETURN_VALUE;

            }
            catch (Exception ex)
            {
                return Result<int>.Failure<int>(new Error("UpdateEmployeeCommandHandler.Handle", Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}