using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Shared.Commands.HumanResources;
using FluentValidation;
using FluentValidation.TestHelper;

namespace AWC.UnitTest.FluentValidators.HumanResources
{
    public class PayHistoryCommandCreateValidatorTest
    {
        private readonly PayHistoryCreateValidator _payHistoryValidator;

        public PayHistoryCommandCreateValidatorTest()
            => _payHistoryValidator = new();

        [Fact]
        public void PayHistoryCommandCreateValidator_ValidData_ShouldSucceed()
        {
            PayHistoryCommand command = new()
            {
                BusinessEntityID = 0,
                RateChangeDate = new DateTime(2023, 8, 6),
                Rate = 6.5M,
                PayFrequency = 1
            };

            var result = _payHistoryValidator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void PayHistoryCommandCreateValidator_InvalidBusinessEntityID_ShouldFail()
        {
            PayHistoryCommand command = new()
            {
                BusinessEntityID = 1,
                RateChangeDate = new DateTime(2023, 8, 6),
                Rate = 6.5M,
                PayFrequency = 1
            };

            var result = _payHistoryValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.BusinessEntityID);
        }

        [Fact]
        public void PayHistoryCommandCreateValidator_InvalidDefaultRateChangeDate_ShouldFail()
        {
            PayHistoryCommand command = new()
            {
                BusinessEntityID = 1,
                RateChangeDate = new DateTime(),
                Rate = 6.5M,
                PayFrequency = 1
            };

            var result = _payHistoryValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.RateChangeDate);
        }

        [Theory]
        [InlineData(6.49)]
        [InlineData(200.01)]
        public void PayHistoryCommandCreateValidator_InvalidPayRate_ShouldFail(decimal payRate)
        {
            PayHistoryCommand command = new()
            {
                BusinessEntityID = 0,
                RateChangeDate = new DateTime(2023, 8, 6),
                Rate = (decimal)payRate,
                PayFrequency = 1
            };

            var result = _payHistoryValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Rate);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void PayHistoryCommandCreateValidator_InvalidPayFrequency_ShouldFail(int payFrequency)
        {
            PayHistoryCommand command = new()
            {
                BusinessEntityID = 0,
                RateChangeDate = new DateTime(2023, 8, 6),
                Rate = 6.5M,
                PayFrequency = payFrequency
            };

            var result = _payHistoryValidator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.PayFrequency);
        }
    }
}