using AWC.Application.BusinessRules.HumanResources;
using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.DeleteEmployee
{
    public sealed class DeleteEmployeeBusinessRuleValidator : CommandValidator<DeleteEmployeeCommand>
    {
        private readonly IValidationRepositoryManager _repo;

        public DeleteEmployeeBusinessRuleValidator(IValidationRepositoryManager repo)
            => _repo = repo;

        public override async Task<Result> Validate(DeleteEmployeeCommand command)
        {
            DeleteEmployeeMustExist verifyEmployeeExist = new(_repo);

            ValidationResult result = await verifyEmployeeExist.Validate(command);

            if (result.IsValid)
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(new Error("DeleteEmployeeBusinessRuleValidator.Validate", result.Messages[0]));
            }
        }
    }
}