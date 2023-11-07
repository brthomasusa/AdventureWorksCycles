using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public class ShiftName : ValueObject
    {
        public const int MAX_LENGTH = 50;

        public string Value { get; }

        private ShiftName(string name) => Value = name;

        public static implicit operator string(ShiftName self) => self.Value!;

        public static ShiftName Create(string value)
        {
            CheckValidity(value);
            return new ShiftName(value);
        }

        private static void CheckValidity(string shiftName)
        {
            Guard.Against.NullOrEmpty(shiftName);
            Guard.Against.LengthGreaterThan(shiftName, MAX_LENGTH);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}