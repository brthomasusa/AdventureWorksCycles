using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.BusinessRules.HumanResources
{
    public sealed class UpdateEmployeeNameMustBeUnique : BusinessRule<UpdateEmployeeCommand>
    {
        private readonly IValidationRepositoryManager _repository;

        public UpdateEmployeeNameMustBeUnique(IValidationRepositoryManager repo)
            => _repository = repo;

        public override async Task<ValidationResult> Validate(UpdateEmployeeCommand employee)
        {
            ValidationResult validationResult = new();

            Result result =
                await _repository.EmployeeAggregateRepository.ValidatePersonNameIsUnique(employee.EmployeeID, employee.FirstName, employee.LastName, employee.MiddleName);

            if (result.IsSuccess)
            {
                validationResult.IsValid = true;

                if (Next is not null)
                    validationResult = await Next.Validate(employee);
            }
            else
            {
                validationResult.Messages.Add(result.Error.Message);
            }

            return validationResult;
        }
    }
}