using AWC.Application.BusinessRules.HumanResources;
using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
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
            CreateEmployeeNameMustBeUnique verifyNameIsUniqueRule = new(_repo);
            CreateEmployeeEmailMustBeUnique verifyEmailIsUniqueRule = new(_repo);
            CreateEmployeeNationalIdNumberMustBeUnique verifyNationalIdIsUniqueRule = new(_repo);
            CreateEmployeeDepartmentMustExist verifyDeptExistRule = new(_repo);
            CreateEmployeeShiftMustExist verifyShiftExistRule = new(_repo);
            CreateEmployeeManagerMustExist verifyMgrExistRule = new(_repo);

            verifyNameIsUniqueRule.SetNext(verifyEmailIsUniqueRule);
            verifyEmailIsUniqueRule.SetNext(verifyNationalIdIsUniqueRule);
            verifyNationalIdIsUniqueRule.SetNext(verifyDeptExistRule);
            verifyShiftExistRule.SetNext(verifyMgrExistRule);

            ValidationResult result = await verifyNameIsUniqueRule.Validate(command);

            if (result.IsValid)
            {
                return Result.Success();
            }
            else
            {
                return Result.Failure(new Error("CreateEmployeeBusinessRuleValidator.Validate", result.Messages.FirstOrDefault()!));
            }
        }
    }
}