#pragma warning disable CS8618

using AWC.SharedKernel.Base;

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

        private static void CheckValidity(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), "The marital status is required.");
            }

            if (!string.Equals(value, "M", StringComparison.OrdinalIgnoreCase) && !string.Equals(value, "S", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid marital status, valid statues are 'S' and 'M'.", nameof(value));
            }
        }
    }
}