using System.Globalization;
using System.Text.RegularExpressions;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.Shared.ValueObjects
{
    public sealed class EmailAddressVO : ValueObject
    {
        public string? Value { get; }

        private EmailAddressVO(string email)
            => Value = email;

        public static implicit operator string(EmailAddressVO self) => self.Value!;

        public static EmailAddressVO Create(string value)
        {
            CheckValidity(value);
            return new EmailAddressVO(value);
        }

        private static void CheckValidity(string emailAddress)
        {
            Guard.Against.NullOrEmpty(emailAddress);
            Guard.Against.LengthGreaterThan(emailAddress, 50);

            if (!IsValidEmail(emailAddress))
            {
                throw new ArgumentException("Invalid email addresss.", nameof(emailAddress));
            }
        }

        // Credit where credit due; thank you Microsoft! 
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format

        private static bool IsValidEmail(string email)
        {
            try
            {
                // Normalize the domain
                email = Regex.Replace(email, "(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                static string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}