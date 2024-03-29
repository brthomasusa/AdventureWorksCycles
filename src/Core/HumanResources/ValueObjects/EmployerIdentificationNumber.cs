using System.Text.RegularExpressions;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.HumanResources.ValueObjects
{
    public sealed partial class EmployerIdentificationNumber : ValueObject
    {
        public string? Value { get; init; }

        private EmployerIdentificationNumber(string ein)
            => Value = ein;

        public static implicit operator string(EmployerIdentificationNumber self) => self.Value!;

        public static EmployerIdentificationNumber Create(string ein)
        {
            CheckValidity(ein);
            return new EmployerIdentificationNumber(ein);
        }

        private static void CheckValidity(string ein)
        {
            Guard.Against.NullOrEmpty(ein, "EmployerIdentificationNumber", "An employer identification number is require.");

            if (!EinRegex().IsMatch(ein))
                throw new ArgumentException($"Invalid employer identification number {ein}!");
        }

        [GeneratedRegex("^\\d{9}|\\d{2}-\\d{7}$")]
        private static partial Regex EinRegex();
    }
}