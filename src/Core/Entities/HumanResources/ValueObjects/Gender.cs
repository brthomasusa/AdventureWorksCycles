using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public sealed class Gender : ValueObject
    {
        public string Value { get; }

        private Gender(string value)
            => Value = value.ToUpper();

        public static implicit operator string(Gender self) => self.Value;

        public static Gender Create(string gender)
        {
            CheckValidity(gender);
            return new Gender(gender);
        }

        private static void CheckValidity(string gender)
        {
            Guard.Against.NullOrEmpty(gender);

            if (!string.Equals(gender, "M", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(gender, "F", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid gender, valid genders are 'M' for male and 'F' for female.");
            }
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}