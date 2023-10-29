using AWC.SharedKernel.Base;

namespace AWC.Core.Entities.Shared.ValueObjects
{
    public sealed class DecimalNotNegative : ValueObject
    {
        public decimal Value { get; }

        private DecimalNotNegative(decimal amount)
        {
            Value = amount;
        }

        public static implicit operator decimal(DecimalNotNegative self) => self.Value;

        public static DecimalNotNegative Create(decimal amount)
        {
            CheckValidity(amount);
            return new DecimalNotNegative(amount);
        }

        private static void CheckValidity(decimal value)
        {
            if (value % 0.01M != 0)
            {
                throw new ArgumentException("The amount can not have more than two decimal places");
            }

            if (value < 0)
            {
                throw new ArgumentException("The amount can not be negative.");
            }
        }
    }
}