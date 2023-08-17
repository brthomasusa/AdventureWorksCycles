using AWC.SharedKernel.Base;

namespace AWC.Core.HumanResources.ValueObjects
{
    public sealed class SickLeave : ValueObject
    {
        public int Value { get; }

        private SickLeave(int hours)
        {
            Value = hours;
        }

        public static implicit operator int(SickLeave self) => self.Value!;

        public static SickLeave Create(int value)
        {
            CheckValidity(value);
            return new SickLeave(value);
        }

        private static void CheckValidity(int value)
        {
            if (value < 0 || value > 120)
                throw new ArgumentException("Sick leave hours must be between 0 and 120");
        }
    }
}