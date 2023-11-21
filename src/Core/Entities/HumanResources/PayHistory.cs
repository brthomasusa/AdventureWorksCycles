using AWC.Core.Enums;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Core.Entities.HumanResources.ValueObjects;
using AWC.Core.Entities.Shared.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.Entities.HumanResources
{
    public sealed class PayHistory : Entity<PayHistoryID>
    {
        private PayHistory
        (
            PayHistoryID id,
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
            PayHistoryID id,
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

        public DateOfRateChange RateChangeDate { get; private set; }
        public RateOfPay PayRate { get; private set; }
        public PayFrequency PayFrequency { get; private set; }
    }
}