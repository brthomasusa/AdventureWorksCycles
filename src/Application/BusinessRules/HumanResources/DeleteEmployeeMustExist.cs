using AWC.Application.Features.HumanResources.DeleteEmployee;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.BusinessRules.HumanResources
{
    public sealed class DeleteEmployeeMustExist : BusinessRule<DeleteEmployeeCommand>
    {
        private readonly IValidationRepositoryManager _repository;

        public DeleteEmployeeMustExist(IValidationRepositoryManager repo)
            => _repository = repo;

        public override async Task<ValidationResult> Validate(DeleteEmployeeCommand employee)
        {
            ValidationResult validationResult = new();

            Result result =
                await _repository.EmployeeAggregateRepository.ValidateEmployeeExist(employee.EmployeeID);

            if (result.IsSuccess)
            {
                if (Next is not null)
                {
                    validationResult = await Next.Validate(employee);
                }
                else
                {
                    validationResult.IsValid = true;
                }
            }
            else
            {
                validationResult.Messages.Add(result.Error.Message);
            }

            return validationResult;
        }
    }
}