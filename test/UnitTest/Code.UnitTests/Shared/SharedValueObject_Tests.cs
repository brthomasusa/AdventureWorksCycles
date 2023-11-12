using System.Text;
using AWC.Core.Entities.Shared.ValueObjects;
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
            // Arrange
            Currency usdollar = Currency.Create("USD", "U.S. Dollar");
            Money money1 = Money.Create(usdollar, 100M);
            Money money2 = Money.Create(usdollar, 100M);

            // Act
            Money money3 = money1 + money2;

            // Assert
            Assert.Equal(200M, money3.Amount);
        }

        [Fact]
        public void Money_Substract_ShouldSucceed()
        {
            // Arrange
            Currency usdollar = Currency.Create("USD", "U.S. Dollar");
            Money money1 = Money.Create(usdollar, 300M);
            Money money2 = Money.Create(usdollar, 100M);

            // Act
            Money money3 = money1 - money2;

            // Assert
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
            // Arrange
            Currency currency = null!;

            // Act
            var exception = Record.Exception(() => Money.Create(currency, 1.234M));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void Money_Null_Should_ThrowException()
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

        [Fact]
        public void WebsiteUrl_ValidData_ShouldNot_ThrowException()
        {
            // Arrange
            string url = "http://website.info";

            // Act
            var exception = Record.Exception(() => WebsiteUrl.Create(url));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void WebsiteUrl_MissingHTTP_Should_ThrowException()
        {
            // Arrange
            string url = "://website.info";

            // Act
            var exception = Record.Exception(() => WebsiteUrl.Create(url));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void WebsiteUrl_TooLong_Should_ThrowException()
        {
            // Arrange
            StringBuilder sb = new("http://website.info") { Length = 51 };
            string url = sb.ToString();

            // Act
            var exception = Record.Exception(() => WebsiteUrl.Create(url));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void Title_ValidData_NotNull_ShouldNot_ThrowException()
        {
            // Arrange
            string title = "Senor";

            // Act
            var exception = Record.Exception(() => Title.Create(title));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void Title_ValidData_Null_ShouldNot_ThrowException()
        {
            // Arrange
            string title = null!;

            // Act
            var exception = Record.Exception(() => Title.Create(title));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void Title_Invalid_TooLong_Should_ThrowException()
        {
            // Arrange
            StringBuilder sb = new("His Royal Badness") { Length = 9 };
            string title = sb.ToString();

            // Act
            var exception = Record.Exception(() => Title.Create(title));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void Suffix_ValidData_NotNull_ShouldNot_ThrowException()
        {
            // Arrange
            string suffix = "Senior";

            // Act
            var exception = Record.Exception(() => Suffix.Create(suffix));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void Suffix_ValidData_Null_ShouldNot_ThrowException()
        {
            // Arrange
            string? suffix = null;

            // Act
            var exception = Record.Exception(() => Suffix.Create(suffix!));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void Suffix_InvalidData_TooLong_Should_ThrowException()
        {
            // Arrange
            StringBuilder sb = new("The Fifth ") { Length = 11 };
            string? suffix = sb.ToString();

            // Act
            var exception = Record.Exception(() => Suffix.Create(suffix!));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void PointOfContact_ValidData_Should_NotThrowException()
        {
            // Arrange
            string first = "Joe";
            string last = "Blow";
            string mi = "J";
            string telephone = "555-555-5555";

            // Act
            var exception = Record.Exception(() => PointOfContact.Create(first, last, mi, telephone));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void PointOfContact_NumMiddleName_Should_NotThrowException()
        {
            // Arrange
            string first = "Joe";
            string last = "Blow";
            string mi = null!;
            string telephone = "555-555-5555";

            // Act
            var exception = Record.Exception(() => PointOfContact.Create(first, last, mi, telephone));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void PointOfContact_NullFirstName_Should_ThrowException()
        {
            // Arrange
            string first = null!;
            string last = "Blow";
            string mi = "J";
            string telephone = "555-555-5555";

            // Act
            var exception = Record.Exception(() => PointOfContact.Create(first, last, mi, telephone));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void PointOfContact_NullLastName_Should_ThrowException()
        {
            // Arrange
            string first = "Joe";
            string last = null!;
            string mi = "J";
            string telephone = "555-555-5555";

            // Act
            var exception = Record.Exception(() => PointOfContact.Create(first, last, mi, telephone));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void PointOfContact_NullTelephone_Should_ThrowException()
        {
            // Arrange
            string first = "Joe";
            string last = "Blow";
            string mi = "J";
            string telephone = null!;

            // Act
            var exception = Record.Exception(() => PointOfContact.Create(first, last, mi, telephone));

            // Assert
            Assert.NotNull(exception);
        }


        [Fact]
        public void PointOfContact_LastNameTooLong_Should_ThrowException()
        {
            // Arrange
            string first = "Joe";
            string last = "Blow";
            string mi = "J";

            StringBuilder sb = new("555-555-5555") { Length = 26 };
            string? telephone = sb.ToString();

            // Act
            var exception = Record.Exception(() => PointOfContact.Create(first, last, mi, telephone));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void PointOfContact_TelephoneTooLong_Should_ThrowException()
        {
            // Arrange
            string first = "Joe";
            string mi = "J";
            string telephone = "555-555-5555";
            StringBuilder sb = new("LongLastName") { Length = 51 };
            string? last = sb.ToString();

            // Act
            var exception = Record.Exception(() => PointOfContact.Create(first, last, mi, telephone));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void OrganizationName_ValidData_should_NotThrowException()
        {
            // Arrange
            string orgName = "IBM";

            // Act
            var exception = Record.Exception(() => OrganizationName.Create(orgName));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void OrganizationName_NullName_shouldNot_ThrowException()
        {
            // Company name and legal name are both organization names
            // company name can not be null but legal name can be null

            // Arrange
            string orgName = null!;

            // Act
            var exception = Record.Exception(() => OrganizationName.Create(orgName));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void OrganizationName_OrgNameTooLong_should_ThrowException()
        {
            // Arrange9+
            StringBuilder sb = new("LongOrgName") { Length = 51 };
            string orgName = sb.ToString();

            // Act
            var exception = Record.Exception(() => OrganizationName.Create(orgName));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void PersonName_ValidData_MiddleName_NotNull_ShouldNot_ThrowException()
        {
            // Arrange
            string firstName = "Joe";
            string lastName = "Blow";
            string middleName = "J";

            // Act
            var exception = Record.Exception(() => PersonName.Create(lastName, firstName, middleName));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void PersonName_ValidData_MiddleName_Null_ShouldNot_ThrowException()
        {
            // Arrange
            string firstName = "Joe";
            string lastName = "Blow";

            // Act
            var exception = Record.Exception(() => PersonName.Create(lastName, firstName, null!));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void PersonName_InvalidData_FirstName_Null_Should_ThrowException()
        {
            // Arrange
            string lastName = "Blow";
            string middleName = "J";

            // Act
            var exception = Record.Exception(() => PersonName.Create(lastName, null!, middleName));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void PersonName_InvalidData_LastName_Null_Should_ThrowException()
        {
            // Arrange
            string firstName = "Joe";
            string middleName = "J";

            // Act
            var exception = Record.Exception(() => PersonName.Create(null!, firstName, middleName));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void PersonName_InvalidData_FirstName_TooLong_Should_ThrowException()
        {
            // Arrange
            StringBuilder sb = new("LongOrgName") { Length = 51 };
            string firstName = sb.ToString();
            string lastName = "Blow";
            string middleName = "J";

            // Act
            var exception = Record.Exception(() => PersonName.Create(lastName, firstName, middleName));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void PersonName_InvalidData_LastName_TooLong_Should_ThrowException()
        {
            // Arrange
            StringBuilder sb = new("LongOrgName") { Length = 51 };
            string firstName = "Joe";
            string lastName = sb.ToString();
            string middleName = "J";

            // Act
            var exception = Record.Exception(() => PersonName.Create(lastName, firstName, middleName));

            // Assert
            Assert.NotNull(exception);
        }


        [Theory]
        [InlineData("SC")]
        [InlineData("IN")]
        [InlineData("SP")]
        [InlineData("EM")]
        [InlineData("VC")]
        [InlineData("GC")]
        public void PersonType_ValidData_ShouldNot_ThrowException(string personType)
        {
            // Arrange

            // Act
            var exception = Record.Exception(() => PersonType.Create(personType));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void PersonType_InvalidData_Should_ThrowException()
        {
            // Arrange
            string personType = "EMM";

            // Act
            var exception = Record.Exception(() => PersonType.Create(personType));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void Email_ValidData_ShouldNot_ThrowException()
        {
            // Arrange
            string email = @"j.sanchez@aventureworks.com";
            // Act
            var exception = Record.Exception(() => Email.Create(email));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("j.sanchez.aventureworks.com")]
        [InlineData(@"@aventureworks.com")]
        [InlineData("j.sanchez@")]
        [InlineData(@"paul@.com")]
        public void Email_InvalidData_Should_ThrowException(string badEmail)
        {
            // Arrange

            // Act
            var exception = Record.Exception(() => Email.Create(badEmail));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void Currency_ValidData_ShouldNot_ThrowException()
        {
            // Arrange
            string code = "USD";
            string name = "U.S. Dollar";

            // Act
            var exception = Record.Exception(() => Currency.Create(code, name));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void Currency_InvalidData_MissingCurrencyCode_Should_ThrowException()
        {
            // Arrange
            string name = "U.S. Dollar";

            // Act
            var exception = Record.Exception(() => Currency.Create(null!, name));

            // Assert
            Assert.NotNull(exception);
        }


        [Fact]
        public void Currency_InvalidData_MissingCurrencyName_Should_ThrowException()
        {
            // Arrange
            string code = "USD";

            // Act
            var exception = Record.Exception(() => Currency.Create(code, null!));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void Currency_InvalidData_CurrencyCodeTooLong_Should_ThrowException()
        {
            // Arrange
            string code = "USDD";
            string name = "U.S. Dollar";

            // Act
            var exception = Record.Exception(() => Currency.Create(code, name));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void Currency_InvalidData_CurrencyNameTooLong_Should_ThrowException()
        {
            // Arrange
            string code = "USD";
            StringBuilder sb = new("U.S. Dollar") { Length = 51 };
            string name = sb.ToString();

            // Act
            var exception = Record.Exception(() => Currency.Create(code, name));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void Currency_CompareEqual()
        {
            // Arrange
            Currency currency1 = Currency.Create("USD", "U.S. Dollar");
            Currency currency2 = Currency.Create("USD", "U.S. Dollar");

            // Act

            // Assert
            Assert.Equal(currency1, currency2);
        }

        [Fact]
        public void Currency_CompareNotEqual()
        {
            // Arrange
            Currency currency1 = Currency.Create("USD", "U.S. Dollar");
            Currency currency2 = Currency.Create("CAN", "Canadian Dollar");

            // Act

            // Assert
            Assert.NotEqual(currency1, currency2);
        }











    }
}