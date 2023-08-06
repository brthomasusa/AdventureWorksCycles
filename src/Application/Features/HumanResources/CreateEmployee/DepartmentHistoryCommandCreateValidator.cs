using AWC.Shared.Commands.HumanResources;
using FluentValidation;

namespace AWC.Application.Features.HumanResources.CreateEmployee
{
    public class DepartmentHistoryCommandCreateValidator : AbstractValidator<DepartmentHistoryCommand>
    {
        public DepartmentHistoryCommandCreateValidator()
        {
            RuleFor(departHistory => departHistory.BusinessEntityID)
                                                  .Equal(0)
                                                  .WithMessage("BusinessEntityID for new department history should be zero.");

            RuleFor(departHistory => departHistory.DepartmentID)
                                                  .GreaterThan(0)
                                                  .WithMessage("A department ID is required.");

            RuleFor(departHistory => departHistory.ShiftID)
                                                  .GreaterThan(0)
                                                  .WithMessage("A shift ID is required.");

            RuleFor(departHistory => departHistory.StartDate)
                                                  .NotEmpty().WithMessage("Start date (employee hire date) is required.");

            RuleFor(departHistory => departHistory.EndDate)
                                                  .Null().WithMessage("A new employee should not have a department end date.");
        }
    }
}