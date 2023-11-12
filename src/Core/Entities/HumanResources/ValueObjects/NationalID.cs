using System.Text.RegularExpressions;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public sealed partial class NationalID : ValueObject
    {
        public string Value { get; }

        private NationalID(string idNumber)
        {
            Value = idNumber;
        }

        public static implicit operator string(NationalID self) => self.Value!;

        public static NationalID Create(string nationalIdNumber)
        {
            CheckValidity(nationalIdNumber);
            return new NationalID(nationalIdNumber);
        }

        private static void CheckValidity(string nationalIdNumber)
        {
            Guard.Against.NullOrEmpty(nationalIdNumber);

            Regex validateNationalIdNumberRegex = MyRegex();
            if (!validateNationalIdNumberRegex.IsMatch(nationalIdNumber))
                throw new ArgumentException($"{nationalIdNumber} is not a valid national id number, should be 5 - 9 digits.");
        }

        [GeneratedRegex("^\\d{5,9}$")]
        private static partial Regex MyRegex();

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}