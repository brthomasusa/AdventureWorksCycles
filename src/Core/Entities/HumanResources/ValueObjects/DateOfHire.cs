using AWC.SharedKernel.Base;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public sealed class DateOfHire : ValueObject
    {
        public DateOnly Value { get; }

        private DateOfHire(DateOnly hireDate)
        {
            Value = hireDate;
        }

        public static implicit operator DateOnly(DateOfHire self) => self.Value!;

        public static DateOfHire Create(DateOnly value)
        {
            CheckValidity(value);
            return new DateOfHire(value);
        }

        private static void CheckValidity(DateOnly hireDate)
        {
            DateTime temp = DateTime.Now;
            DateOnly today = new(temp.Year, temp.Month, temp.Day);

            if (hireDate < new DateOnly(1996, 7, 1) || hireDate > today.AddDays(1))
            {
                throw new ArgumentException($"Employee hire date must be between 1996-7-1 and {today.AddDays(1).ToShortDateString}");
            }
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value!;
        }
    }
}