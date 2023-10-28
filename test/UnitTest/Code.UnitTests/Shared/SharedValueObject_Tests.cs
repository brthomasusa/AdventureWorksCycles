using AWC.Core.Shared.ValueObjects;
using AWC.SharedKernel.Exceptions;

namespace AWC.UnitTest.Code.UnitTests.Shared
{
    public class SharedValueObject_Tests
    {
        [Fact]
        public void Money_CompareForEquality_ShouldSucceed()
        {
            Money money1 = Money.Create(Currency.Create("USD", "U.S. Dollar"), 100M);
            Money money2 = Money.Create(Currency.Create("USD", "U.S. Dollar"), 100M);
            Assert.Equal(money1, money2);
        }

        [Fact]
        public void Money_CompareForEquality_ShouldFail()
        {
            Money money1 = Money.Create(Currency.Create("USD", "U.S. Dollar"), 100M);
            Money money2 = Money.Create(Currency.Create("USD", "U.S. Dollar"), 99.99M);
            Assert.NotEqual(money1, money2);
        }

        [Fact]
        public void Money_Add_ShouldSucceed()
        {
            Money money1 = Money.Create(Currency.Create("USD", "U.S. Dollar"), 100M);
            Money money2 = Money.Create(Currency.Create("USD", "U.S. Dollar"), 100M);
            Money money3 = money1 + money2;

            Assert.Equal(200M, money3.Amount);
        }

        [Fact]
        public void Money_Substract_ShouldSucceed()
        {
            Money money1 = Money.Create(Currency.Create("USD", "U.S. Dollar"), 300M);
            Money money2 = Money.Create(Currency.Create("USD", "U.S. Dollar"), 100M);
            Money money3 = money1 - money2;

            Assert.Equal(200M, money3.Amount);
        }

        [Fact]
        public void Money_MoreThan2DecimalPlaces_ShouldFail()
        {
            var exception = Record.Exception(() => Money.Create(Currency.Create("USD", "U.S. Dollar"), 1.234M));
            Assert.NotNull(exception);
        }

        [Fact]
        public void Money_NegativeMoneyAmount_ShouldFail()
        {
            Currency currency = Currency.Create("USD", "U.S. Dollar");

            Assert.Throws<DomainException>(() => Money.Create(currency, -1M));
        }

        [Fact]
        public void AddressVO_ValidData_ShouldSucceed()
        {
            const string line1 = "123 Main Plaza";
            const string line2 = "Ste 123";
            const string city = "Anywhere";
            const int stateCode = 1;
            const string postal = "99999";

            AddressVO address = AddressVO.Create(line1, line2, city, stateCode, postal);

            Assert.NotNull(address);
        }

        [Fact]
        public void AddressVO_ValidData_NullLine2_ShouldSucceed()
        {
            const string line1 = "123 Main Plaza";
            const string? line2 = null;
            const string city = "Anywhere";
            const int stateCode = 1;
            const string postal = "99999";

            AddressVO address = AddressVO.Create(line1, line2, city, stateCode, postal);

            Assert.NotNull(address);
        }

        [Fact]
        public void AddressVO_EmptyStringLine1_ShouldFail()
        {
            const string? line1 = "";
            const string line2 = "Ste 123";
            const string city = "Anywhere";
            const int stateCode = 1;
            const string postal = "99999";

            var exception = Record.Exception(() => AddressVO.Create(line1, line2, city, stateCode, postal));
            Assert.NotNull(exception);
        }
    }
}