using System.Text.RegularExpressions;
using AWC.SharedKernel.Base;

namespace AWC.Core.HumanResources.ValueObjects
{
    public sealed partial class NationalID : ValueObject
    {
        public string? Value { get; }

        private NationalID(string idNumber)
        {
            Value = idNumber;
        }

        public static implicit operator string(NationalID self) => self.Value!;

        public static NationalID Create(string idNumber)
        {
            CheckValidity(idNumber);
            return new NationalID(idNumber);
        }

        private static void CheckValidity(string idNumber)
        {
            if (string.IsNullOrEmpty(idNumber))
            {
                throw new ArgumentNullException(nameof(idNumber), "The national id number is required.");
            }

            if (idNumber.Length > 15)
            {
                throw new ArgumentException("Invalid national id number, maximum length is 15 characters.");
            }

            Regex validateNationalIdNumberRegex = MyRegex();
            if (!validateNationalIdNumberRegex.IsMatch(idNumber))
                throw new ArgumentException($"{idNumber} is not a valid national id number, should be 5 - 9 digits.");
        }

        [GeneratedRegex("^\\d{5,9}$")]
        private static partial Regex MyRegex();
    }
}