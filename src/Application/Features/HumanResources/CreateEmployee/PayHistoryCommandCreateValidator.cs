using AWC.Shared.Commands.HumanResources;
using FluentValidation;

namespace AWC.Application.Features.HumanResources.CreateEmployee
{
    public class PayHistoryCommandCreateValidator : AbstractValidator<PayHistoryCommand>
    {
        public PayHistoryCommandCreateValidator()
        {
            RuleFor(payHistory => payHistory.BusinessEntityID)
                                            .Equal(0)
                                            .WithMessage("BusinessEntityID for new pay history should be zero.");

            RuleFor(payHistory => payHistory.RateChangeDate)
                                            .NotEmpty().WithMessage("Rate change date (employee hire date) is required.");

            RuleFor(payHistory => payHistory.Rate)
                                            .Must(pay => pay >= 6.50M && pay <= 200M)
                                            .WithMessage("Valid pay rate is between $6.50 and $200.00 per hour.");

            RuleFor(payHistory => payHistory.PayFrequency)
                                            .Must(freq => freq == 1 || freq == 2)
                                            .WithMessage("Valid pay frequencies are 1 for monthly and 2 for biweekly.");
        }
    }
}