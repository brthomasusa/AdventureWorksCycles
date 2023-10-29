using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.Shared.ValueObjects
{
    public sealed class Money : ValueObject
    {
        private Money(Currency currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        public Currency Currency { get; init; }
        public decimal Amount { get; init; }

        public static Money Create(Currency currency, decimal amount)
        {
            CheckValidity(currency, amount);
            return new Money(currency, amount);
        }

        public static Money operator +(Money left, Money right)
        {
            if (left.Currency == right.Currency)
                return new(left.Currency, left.Amount + right.Amount);
            else
                throw new ArgumentException($"Left money currency {left.Currency.CurrencyName} does not match right money currency {right.Currency.CurrencyName}.");
        }

        public static Money operator -(Money left, Money right)
        {
            if (left.Currency == right.Currency)
                return new(left.Currency, left.Amount - right.Amount);
            else
                throw new ArgumentException($"Left money currency {left.Currency.CurrencyName} does not match right money currency {right.Currency.CurrencyName}.");
        }

        private static void CheckValidity(Currency currency, decimal amount)
        {
            if (currency is null)
                throw new ArgumentException("A currency is required.");

            Guard.Against.LessThan(amount, 0M, "Money can not be negative.");
            Guard.Against.GreaterThanTwoDecimalPlaces(amount);
        }
    }
}