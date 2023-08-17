using System.Text.RegularExpressions;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Shared.ValueObjects
{
    public sealed partial class PhoneNumber : ValueObject
    {
        public string? Value { get; }

        private PhoneNumber(string phoneNumber)
        {
            Value = phoneNumber;
        }

        public static implicit operator string(PhoneNumber self) => self.Value!;

        public static PhoneNumber Create(string phoneNumber)
        {
            CheckValidity(phoneNumber);
            return new PhoneNumber(phoneNumber);
        }

        private static void CheckValidity(string value)
        {
            Guard.Against.NullOrEmpty(value, "PhoneNumber", "The PhoneNumber number is required.");
            Guard.Against.LengthGreaterThan(value, 25, "PhoneNumber", "Invalid PhoneNumber number, maximum length is 25 characters.");

            Regex validatePhoneNumberRegex = TelephoneRegex();
            if (!validatePhoneNumberRegex.IsMatch(value))
                throw new ArgumentException($"{value} is not a valid phone number.");
        }

        [GeneratedRegex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$")]
        private static partial Regex TelephoneRegex();
    }
}