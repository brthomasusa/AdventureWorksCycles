using AWC.Application.BusinessRules.HumanResources;
using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.UpdateEmployee
{
    public sealed class UpdateEmployeeBusinessRuleValidator : CommandValidator<UpdateEmployeeCommand>
    {
        private readonly IValidationRepositoryManager _repo;

        public UpdateEmployeeBusinessRuleValidator(IValidationRepositoryManager repo)
            => _repo = repo;

        public override async Task<Result> Validate(UpdateEmployeeCommand command)
        {
            UpdateEmployeeMustExist verifyEmployeeExist = new(_repo);
            UpdateEmployeeNameMustBeUnique verifyNameIsUnique = new(_repo);
            UpdateEmployeeNationalIdNumberMustBeUnique verifyNationalIdIsUnique = new(_repo);

            verifyEmployeeExist.SetNext(verifyNameIsUnique);
            verifyNameIsUnique.SetNext(verifyNationalIdIsUnique);

            ValidationResult result = await verifyEmployeeExist.Validate(command);

            if (result.IsValid)
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(new Error("UpdateEmployeeBusinessRuleValidator.Validate", result.Messages[0]));
            }
        }
    }
}