using FluentValidation;

namespace AWC.Application.Features.HumanResources.DeleteEmployee
{
    public sealed class DeleteEmployeeCommandDataValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandDataValidator()
        {
            RuleFor(employee => employee.BusinessEntityID)
                                        .GreaterThan(0)
                                        .WithMessage("An ID is required in order to locate the employee to be deleted.");
        }
    }
}