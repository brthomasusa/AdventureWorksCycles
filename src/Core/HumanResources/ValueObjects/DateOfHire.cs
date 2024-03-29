using AWC.SharedKernel.Base;

namespace AWC.Core.HumanResources.ValueObjects
{
    public sealed class DateOfHire : ValueObject
    {
        public DateOnly Value { get; }

        private DateOfHire(DateOnly birthDate)
        {
            Value = birthDate;
        }

        public static implicit operator DateOnly(DateOfHire self) => self.Value!;

        public static DateOfHire Create(DateOnly value)
        {
            CheckValidity(value);
            return new DateOfHire(value);
        }

        private static void CheckValidity(DateOnly value)
        {
            DateTime temp = DateTime.Now;
            DateOnly today = new(temp.Year, temp.Month, temp.Day);

            if (value < new DateOnly(1996, 7, 1) || value > today.AddDays(1))
            {
                throw new ArgumentException($"Employment date must be between 1996-7-1 and {today.AddDays(1).ToShortDateString}");
            }
        }
    }
}