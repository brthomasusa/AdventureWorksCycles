using AWC.Shared.Commands.HumanResources;
using FluentValidation;

namespace AWC.Application.Features.HumanResources.CreateEmployee
{
    public class DepartmentHistoryCreateValidator : AbstractValidator<DepartmentHistoryCommand>
    {
        public DepartmentHistoryCreateValidator()
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
        }
    }
}