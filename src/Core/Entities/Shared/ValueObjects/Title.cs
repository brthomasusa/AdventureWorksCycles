using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.Shared.ValueObjects
{
    public sealed class Title : ValueObject
    {
        public string? Value { get; }

        private Title(string title)
            => Value = title;

        public static implicit operator string(Title self) => self.Value!;

        public static Title Create(string value)
        {
            CheckValidity(value);
            return new Title(value);
        }

        private static void CheckValidity(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                Guard.Against.LengthGreaterThan(title, 8);
            }
        }
    }
}