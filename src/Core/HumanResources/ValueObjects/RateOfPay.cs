using AWC.Core.Shared.ValueObjects;
using AWC.SharedKernel.Base;
namespace AWC.Core.HumanResources.ValueObjects
{
    public sealed class RateOfPay : ValueObject
    {
        public Money Value { get; }

        private RateOfPay(Money rate)
        {
            Value = rate;
        }

        public static implicit operator Money(RateOfPay self) => self.Value!;

        public static RateOfPay Create(Money value)
        {
            CheckValidity(value);
            return new RateOfPay(value);
        }

        private static void CheckValidity(Money money)
        {
            if (money.Amount < 6.50M || money.Amount > 40.00M)
                throw new ArgumentException("Invalid pay rate, must be between $6.50 and $40.00");
        }
    }
}