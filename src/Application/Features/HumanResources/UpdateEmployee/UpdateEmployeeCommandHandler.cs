using AWC.Application.Interfaces.Messaging;
using AWC.Core.HumanResources;
using AWC.Core.Shared;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Utilities;
using MediatR;

namespace AWC.Application.Features.HumanResources.UpdateEmployee
{
    public sealed class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, int>
    {
        private const int RETURN_VALUE = 0;
        private readonly IWriteRepositoryManager _repo;

        public UpdateEmployeeCommandHandler(IWriteRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<int>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Result<Employee> getEmployee = await _repo.EmployeeAggregateRepository.GetByIdAsync(request.BusinessEntityID);

                if (getEmployee.IsFailure)
                    return Result<int>.Failure<int>(new Error("UpdateEmployeeCommandHandler.Handle", getEmployee.Error.Message));

                Result<Employee> updateEmployee = getEmployee.Value.Update
                (
                    "EM",
                    request.NameStyle == 0 ? NameStyleEnum.Western : NameStyleEnum.Eastern,
                    request.Title!,
                    request.FirstName,
                    request.LastName,
                    request.MiddleName!,
                    request.Suffix!,
                    (EmailPromotionEnum)request.EmailPromotion,
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

                if (updateEmployee.IsFailure)
                    return Result<int>.Failure<int>(new Error("UpdateEmployeeCommandHandler.Handle", updateEmployee.Error.Message));

                Result<int> updateDbResult = await _repo.EmployeeAggregateRepository.Update(updateEmployee.Value);

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