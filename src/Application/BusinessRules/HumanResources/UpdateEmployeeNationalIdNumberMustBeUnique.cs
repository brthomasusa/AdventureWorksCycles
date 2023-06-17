using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.BusinessRules.HumanResources
{
    public sealed class UpdateEmployeeNationalIdNumberMustBeUnique : BusinessRule<UpdateEmployeeCommand>
    {
        private readonly IValidationRepositoryManager _repository;

        public UpdateEmployeeNationalIdNumberMustBeUnique(IValidationRepositoryManager repo)
            => _repository = repo;

        public override async Task<ValidationResult> Validate(UpdateEmployeeCommand employee)
        {
            ValidationResult validationResult = new();

            Result result =
                await _repository.EmployeeAggregateRepository.ValidateNationalIdNumberIsUnique(employee.EmployeeID, employee.NationalID);

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