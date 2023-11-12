using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public sealed class DateOfRateChange : ValueObject
    {
        public DateTime Value { get; }

        private DateOfRateChange(DateTime rateChangeDate)
            => Value = rateChangeDate;

        public static implicit operator DateTime(DateOfRateChange self) => self.Value!;

        public static DateOfRateChange Create(DateTime value)
        {
            CheckValidity(value);
            return new DateOfRateChange(value);
        }

        private static void CheckValidity(DateTime rateChangeDate)
        {
            Guard.Against.DefaultDateTime(rateChangeDate, "The date the rate of pay was set (or changed) is required.");
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value!;
        }
    }
}