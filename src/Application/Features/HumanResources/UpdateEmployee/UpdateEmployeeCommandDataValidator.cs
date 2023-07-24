using FluentValidation;

namespace AWC.Application.Features.HumanResources.UpdateEmployee
{
    public sealed class UpdateEmployeeCommandDataValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandDataValidator()
        {
            RuleFor(employee => employee.BusinessEntityID)
                                        .GreaterThan(0)
                                        .WithMessage("An ID is required in order to locate the employee to be updated.");

            RuleFor(employee => employee.Title)
                                        .MaximumLength(8).WithMessage("Title cannot be longer than 8 characters");

            RuleFor(employee => employee.FirstName)
                                        .NotEmpty().WithMessage("Employee first name; this is required.")
                                        .MaximumLength(50).WithMessage("Employee first name cannot be longer than 50 characters");

            RuleFor(employee => employee.LastName)
                                        .NotEmpty().WithMessage("Employee last name; this is required.")
                                        .MaximumLength(50).WithMessage("Employee last name cannot be longer than 50 characters");

            RuleFor(employee => employee.MiddleName)
                                        .MaximumLength(50).WithMessage("Employee middle name cannot be longer than 50 characters");

            RuleFor(employee => employee.Suffix)
                                        .MaximumLength(10).WithMessage("Suffix cannot be longer than 10 characters");

            RuleFor(employee => employee.EmailPromotion)
                                        .Must(emailPromo => emailPromo >= 0 && emailPromo <= 2)
                                        .WithMessage("Valid email promo codes are 0, 1, or 2.");

            RuleFor(employee => employee.NationalIDNumber)
                                        .NotEmpty().WithMessage("National ID; this is required.")
                                        .MaximumLength(50).WithMessage("National ID cannot be longer than 15 characters");

            RuleFor(employee => employee.LoginID)
                                        .NotEmpty().WithMessage("Employee login; this is required.")
                                        .MaximumLength(50).WithMessage("Employee login cannot be longer than 256 characters");

            RuleFor(employee => employee.JobTitle)
                                        .NotEmpty().WithMessage("Employee job title; this is required.")
                                        .MaximumLength(50).WithMessage("Employee job title cannot be longer than 50 characters");

            RuleFor(employee => employee.BirthDate)
                                        .NotEmpty().WithMessage("Employee birth date is required.")
                                        .GreaterThanOrEqualTo(new DateTime(1930, 1, 1)).WithMessage("Birth date must be on or after 1-1-1930.")
                                        .LessThanOrEqualTo(DateTime.Now.AddYears(-18)).WithMessage("Employee must be at least 18 years old.");

            RuleFor(employee => employee.MaritalStatus)
                                        .NotEmpty().WithMessage("Employee marital status is required.")
                                        .Must(status => string.Equals(status, "S", StringComparison.OrdinalIgnoreCase) ||
                                                        string.Equals(status, "M", StringComparison.OrdinalIgnoreCase))
                                        .WithMessage("Marital status must be S for single or M for married.");

            RuleFor(employee => employee.Gender)
                                        .NotEmpty().WithMessage("Employee gender is required.")
                                        .Must(gender => string.Equals(gender, "F", StringComparison.OrdinalIgnoreCase) ||
                                                        string.Equals(gender, "M", StringComparison.OrdinalIgnoreCase))
                                        .WithMessage("Gender must be F for female or M for male.");

            RuleFor(employee => employee.HireDate)
                                        .NotEmpty().WithMessage("Employee hire date is required.")
                                        .Must(hireDate => hireDate >= new DateTime(1996, 7, 1))
                                        .WithMessage("Hire date must be on or after July 1, 1996.");

            RuleFor(employee => employee.VacationHours)
                                        .Must(vacation => vacation >= -40 && vacation <= 240)
                                        .WithMessage("Valid vacation hours are between negative 40 and 240.");

            RuleFor(employee => employee.SickLeaveHours)
                                        .Must(sickleave => sickleave >= 0 && sickleave <= 120)
                                        .WithMessage("Valid sick leave hours are between 0 and 120.");
        }
    }
}