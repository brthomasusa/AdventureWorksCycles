using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public sealed class JobTitle : ValueObject
    {
        public const int MAX_LENGTH = 50;

        public string Value { get; }

        private JobTitle(string value)
            => Value = value;

        public static implicit operator string(JobTitle self) => self.Value;

        public static JobTitle Create(string value)
        {
            CheckValidity(value);
            return new JobTitle(value);
        }

        private static void CheckValidity(string jobTitle)
        {
            Guard.Against.NullOrEmpty(jobTitle);
            Guard.Against.LengthGreaterThan(jobTitle, MAX_LENGTH);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}