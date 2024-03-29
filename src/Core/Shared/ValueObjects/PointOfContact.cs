using System.Text.RegularExpressions;
using AWC.SharedKernel.Base;

namespace AWC.Core.Shared.ValueObjects
{
    public sealed partial class PointOfContact : ValueObject
    {
        private PointOfContact(string fname, string lname, string? mi, string telephone)
        {
            FirstName = fname;
            LastName = lname;
            MiddleInitial = mi;
            Telephone = telephone;
        }

        public string? FirstName { get; }
        public string? LastName { get; }
        public string? MiddleInitial { get; }
        public string? Telephone { get; }

        public static PointOfContact Create(string fname, string lname, string? mi, string telephone)
        {
            CheckValidity(fname, lname, mi, telephone);
            return new PointOfContact(fname, lname, mi, telephone);
        }

        private static void CheckValidity(string last, string first, string? mi, string telephone)
        {
            if (string.IsNullOrEmpty(first))
            {
                throw new ArgumentNullException(nameof(first), "A first name is required.");
            }

            if (string.IsNullOrEmpty(last))
            {
                throw new ArgumentNullException(nameof(last), "A last name is required.");
            }

            first = first.Trim();
            last = last.Trim();

            if (first.Length > 25)
            {
                throw new ArgumentOutOfRangeException(nameof(first), "Maximum length of the first name is 25 characters.");
            }

            if (last.Length > 25)
            {
                throw new ArgumentOutOfRangeException(nameof(last), "Maximum length of the last name is 25 characters.");
            }

            if (!string.IsNullOrEmpty(mi))
            {
                mi = mi.Trim();
                if (mi.Length > 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(mi), "Maximum length of middle initial is 1 character.");
                }
            }

            if (string.IsNullOrEmpty(telephone))
            {
                throw new ArgumentNullException(nameof(telephone), "The PhoneNumber number is required.");
            }

            if (!TelephoneRegex().IsMatch(telephone))
            {
                throw new ArgumentException("Invalid PhoneNumber number!", nameof(telephone));
            }
        }

        [GeneratedRegex("^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]?\\d{3}[\\s.-]?\\d{4}$")]
        private static partial Regex TelephoneRegex();
    }
}