using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Shared.ValueObjects
{
    public sealed class Money : ValueObject
    {
        private Money(string currencyCode, decimal amount)
        {
            CurrencyCode = currencyCode;
            Amount = amount;
        }

        public string CurrencyCode { get; init; }
        public decimal Amount { get; init; }

        public static Money Create(string currencyCode, decimal amount)
        {
            CheckValidity(currencyCode, amount);
            return new Money(currencyCode, amount);
        }

        private static void CheckValidity(string currencyCode, decimal amount)
        {
            Guard.Against.NullOrEmpty(currencyCode, "CurrencyCode", "A currency code (USD, EUR, etc) is required.");
            Guard.Against.LessThanZero(amount, "Amount", "Money amount can not be negative.");
        }
    }
}