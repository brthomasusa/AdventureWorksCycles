using System.Text.RegularExpressions;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.Shared.ValueObjects
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

        private static void CheckValidity(string phoneNumber)
        {
            Guard.Against.NullOrEmpty(phoneNumber);
            Guard.Against.LengthGreaterThan(phoneNumber, 25);

            Regex validatePhoneNumberRegex = TelephoneRegex();
            if (!validatePhoneNumberRegex.IsMatch(phoneNumber))
                throw new ArgumentException($"{phoneNumber} is not a valid phone number.");
        }

        [GeneratedRegex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$")]
        private static partial Regex TelephoneRegex();
    }
}