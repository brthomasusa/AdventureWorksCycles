using AWC.Core.HumanResources.ValueObjects;
using AWC.Core.Shared.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.HumanResources
{
    public sealed class PayHistory : Entity<int>
    {
        private PayHistory
        (
            int id,
            DateOfRateChange rateChangeDate,
            RateOfPay rate,
            PayFrequency payFrequency
        )
        {
            Id = id;
            RateChangeDate = rateChangeDate;
            PayRate = rate;
            PayFrequency = payFrequency;
        }

        internal static Result<PayHistory> Create
        (
            int id,
            DateTime rateChangeDate,
            decimal rate,
            PayFrequency payFrequency
        )
        {
            try
            {
                PayHistory history = new
                    (
                        id,
                        DateOfRateChange.Create(rateChangeDate),
                        RateOfPay.Create(Money.Create(Currency.Create("USD", "US Dollar"), Math.Round(rate, 2))),
                        Enum.IsDefined(typeof(PayFrequency), payFrequency) ? payFrequency :
                                                                                 throw new ArgumentException("Invalid pay frequency.")
                    );
                return history;
            }
            catch (Exception ex)
            {
                return Result<PayHistory>.Failure<PayHistory>(new Error("PayHistory.Create", Helpers.GetExceptionMessage(ex)));
            }
        }

        public DateOfRateChange RateChangeDate { get; }
        public RateOfPay PayRate { get; }
        public PayFrequency PayFrequency { get; }
    }

    public enum PayFrequency
    {
        Monthly = 1,
        BiWeekly = 2
    }
}