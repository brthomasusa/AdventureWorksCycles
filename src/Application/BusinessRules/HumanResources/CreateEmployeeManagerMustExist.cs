using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.BusinessRules.HumanResources
{
    public sealed class CreateEmployeeManagerMustExist : BusinessRule<CreateEmployeeCommand>
    {
        private readonly IValidationRepositoryManager _repository;

        public CreateEmployeeManagerMustExist(IValidationRepositoryManager repo)
            => _repository = repo;

        public override async Task<ValidationResult> Validate(CreateEmployeeCommand employee)
        {
            ValidationResult validationResult = new();

            Result result =
                await _repository.EmployeeAggregateRepository.DoesManagerExist(employee.ManagerID);

            if (result.IsSuccess)
            {
                validationResult.IsValid = true;

                if (Next is not null)
                {
                    validationResult = await Next.Validate(employee);
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