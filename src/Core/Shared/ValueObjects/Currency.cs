using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Shared.ValueObjects
{
    public sealed class Currency : ValueObject
    {
        private Currency(string code, string name)
            => (CurrencyCode, CurrencyName) = (code, name);

        public string? CurrencyCode { get; init; }
        public string? CurrencyName { get; init; }

        public static Currency Create(string code, string name)
        {
            CheckValidity(code, name);
            return new Currency(code, name);
        }

        private static void CheckValidity(string code, string name)
        {
            Guard.Against.NullOrEmpty(code, "CurrencyCode", "A currency code (USD, EUR, etc) is required.");
            Guard.Against.LengthGreaterThan(code, 3, "Max currency code length is three characters.");

            Guard.Against.NullOrEmpty(name, "CurrencyName", "A currency name is required.");
            Guard.Against.LengthGreaterThan(name, 50, "Max currency name length is fifty characters.");
        }
    }
}