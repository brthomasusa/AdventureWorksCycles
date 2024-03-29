using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Shared.ValueObjects
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

        private static void CheckValidity(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Guard.Against.LengthGreaterThan(value, 8, "Title", "The maximum length of the title is 8 characters.");
            }
        }
    }
}