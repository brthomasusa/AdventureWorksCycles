#pragma warning disable CS8618

using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public sealed class MaritalStatus : ValueObject
    {
        public string Value { get; }

        private MaritalStatus(string value)
            => Value = value.ToUpper();

        public static implicit operator string(MaritalStatus self) => self.Value;

        public static MaritalStatus Create(string status)
        {
            CheckValidity(status);
            return new MaritalStatus(status);
        }

        private static void CheckValidity(string maritalStatus)
        {
            Guard.Against.NullOrEmpty(maritalStatus);

            if (!string.Equals(maritalStatus, "M", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(maritalStatus, "S", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid marital status, valid statues are 'S' and 'M'.", nameof(maritalStatus));
            }
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}