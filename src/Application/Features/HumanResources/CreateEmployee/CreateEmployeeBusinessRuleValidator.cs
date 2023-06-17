using AWC.Application.BusinessRules.HumanResources;
using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.CreateEmployee
{
    public sealed class CreateEmployeeBusinessRuleValidator : CommandValidator<CreateEmployeeCommand>
    {
        private readonly IValidationRepositoryManager _repo;

        public CreateEmployeeBusinessRuleValidator(IValidationRepositoryManager repo)
            => _repo = repo;

        public override async Task<Result> Validate(CreateEmployeeCommand command)
        {
            CreateEmployeeNameMustBeUnique verifyNameIsUnique = new(_repo);
            CreateEmployeeEmailMustBeUnique verifyEmailIsUnique = new(_repo);
            CreateEmployeeNationalIdNumberMustBeUnique verifyNationalIdIsUnique = new(_repo);

            verifyNameIsUnique.SetNext(verifyEmailIsUnique);
            verifyEmailIsUnique.SetNext(verifyNationalIdIsUnique);

            ValidationResult result = await verifyNameIsUnique.Validate(command);

            if (result.IsValid)
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(new Error("CreateEmployeeBusinessRuleValidator.Validate", result.Messages[0]));
            }
        }
    }
}