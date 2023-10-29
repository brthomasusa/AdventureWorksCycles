using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.Shared.ValueObjects
{
    public sealed class Suffix : ValueObject
    {
        public string? Value { get; }

        private Suffix(string value)
            => Value = value;

        public static implicit operator string(Suffix self) => self.Value!;

        public static Suffix Create(string value)
        {
            CheckValidity(value);
            return new Suffix(value);
        }

        private static void CheckValidity(string suffix)
        {
            if (!string.IsNullOrEmpty(suffix))
            {
                Guard.Against.LengthGreaterThan(suffix, 10);
            }
        }
    }
}