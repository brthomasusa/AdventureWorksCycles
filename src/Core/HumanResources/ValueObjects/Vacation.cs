using AWC.SharedKernel.Base;

namespace AWC.Core.HumanResources.ValueObjects
{
    public sealed class Vacation : ValueObject
    {
        public int Value { get; }

        private Vacation(int hours)
        {
            Value = hours;
        }

        public static implicit operator int(Vacation self) => self.Value!;

        public static Vacation Create(int value)
        {
            CheckValidity(value);
            return new Vacation(value);
        }

        private static void CheckValidity(int value)
        {
            if (value < -40 || value > 240)
                throw new ArgumentException("Vacation hours must be between -40 and 240");
        }
    }
}