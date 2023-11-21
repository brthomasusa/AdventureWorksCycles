using System.Text;
using AWC.Core.Entities.HumanResources.ValueObjects;
using AWC.Core.Entities.Shared.ValueObjects;

namespace AWC.UnitTest.Code.UnitTests.HumanResources;

public class HrValueObject_Tests
{
    [Fact]
    public void DateOfBirth_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        DateOnly birthDate = new(2000, 6, 12);

        // Act
        var exception = Record.Exception(() => DateOfBirth.Create(birthDate));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void DateOfBirth_UnderAgeLimit_Should_ThrowException()
    {
        // Arrange
        DateOnly birthDate = new(2006, 6, 12);

        // Act
        var exception = Record.Exception(() => DateOfBirth.Create(birthDate));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void DateOfBirth_OverAgeLimit_Should_ThrowException()
    {
        // Arrange
        DateOnly birthDate = new(1929, 12, 31);

        // Act
        var exception = Record.Exception(() => DateOfBirth.Create(birthDate));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void DateOfBirth_CompareEqual()
    {
        // Arrange
        DateOnly first = new(2000, 12, 31);
        DateOnly second = new(2000, 12, 31);

        // Act
        DateOfBirth birth1 = DateOfBirth.Create(first);
        DateOfBirth birth2 = DateOfBirth.Create(second);

        // Assert
        Assert.Equal(birth1, birth2);
    }

    [Fact]
    public void DateOfBirth_CompareNotEqual()
    {
        // Arrange
        DateOnly first = new(2000, 12, 31);
        DateOnly second = new(2000, 1, 31);

        // Act
        DateOfBirth birth1 = DateOfBirth.Create(first);
        DateOfBirth birth2 = DateOfBirth.Create(second);

        // Assert
        Assert.NotEqual(birth1, birth2);
    }

    [Fact]
    public void DateOfHire_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        DateOnly hireDate = new(2000, 6, 12);

        // Act
        var exception = Record.Exception(() => DateOfHire.Create(hireDate));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void DateOfHire_InvalidData_DefaultDate_Should_ThrowException()
    {
        // Arrange
        DateOnly hireDate = new();

        // Act
        var exception = Record.Exception(() => DateOfHire.Create(hireDate));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void DateOfHire_InvalidData_Before_19960701_Should_ThrowException()
    {
        // Arrange
        DateOnly hireDate = new(1996, 6, 30);

        // Act
        var exception = Record.Exception(() => DateOfHire.Create(hireDate));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void DateOfHire_InvalidData_TwoDaysIntoFuture_Should_ThrowException()
    {
        // Arrange
        DateTime temp = DateTime.Now;
        DateOnly today = new(temp.Year, temp.Month, temp.Day);
        DateOnly hireDate = today.AddDays(2);

        // Act
        var exception = Record.Exception(() => DateOfHire.Create(hireDate));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void DateOfHire_CompareEqual()
    {
        // Arrange
        DateOnly hireDate1 = new(2023, 11, 9);
        DateOnly hireDate2 = new(2023, 11, 9);

        // Act
        DateOfHire dateOfHire1 = DateOfHire.Create(hireDate1);
        DateOfHire dateOfHire2 = DateOfHire.Create(hireDate1);

        // Assert
        Assert.Equal(dateOfHire1, dateOfHire2);
    }

    [Fact]
    public void DateOfHire_CompareNotEqual()
    {
        // Arrange
        DateOnly hireDate1 = new(2023, 11, 9);
        DateOnly hireDate2 = new(2023, 11, 8);

        // Act
        DateOfHire dateOfHire1 = DateOfHire.Create(hireDate1);
        DateOfHire dateOfHire2 = DateOfHire.Create(hireDate1);

        // Assert
        Assert.Equal(dateOfHire1, dateOfHire2);
    }

    [Fact]
    public void DateOfRateChange_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        DateTime rateChangeDate = DateTime.Today;

        // Act
        var exception = Record.Exception(() => DateOfRateChange.Create(rateChangeDate));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void DateOfRateChange_InvalidData_DefaultDate_Should_ThrowException()
    {
        // Arrange
        DateTime rateChangeDate = new();

        // Act
        var exception = Record.Exception(() => DateOfRateChange.Create(rateChangeDate));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void DateOfRateChange_CompareEqual()
    {
        // Arrange
        DateTime rateChangeDate1 = new(2023, 11, 9);
        DateTime rateChangeDate2 = new(2023, 11, 9);

        // Act
        DateOfRateChange dateOfRateChange1 = DateOfRateChange.Create(rateChangeDate1);
        DateOfRateChange dateOfRateChange2 = DateOfRateChange.Create(rateChangeDate2);

        // Assert
        Assert.Equal(dateOfRateChange1, dateOfRateChange2);
    }

    [Fact]
    public void DateOfRateChange_CompareNotEqual()
    {
        // Arrange
        DateTime rateChangeDate1 = new(2023, 11, 9);
        DateTime rateChangeDate2 = new(2022, 11, 9);

        // Act
        DateOfRateChange dateOfRateChange1 = DateOfRateChange.Create(rateChangeDate1);
        DateOfRateChange dateOfRateChange2 = DateOfRateChange.Create(rateChangeDate2);

        // Assert
        Assert.NotEqual(dateOfRateChange1, dateOfRateChange2);
    }

    [Fact]
    public void DepartmentStartDate_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        DateOnly deptStartDate = DateOnly.FromDateTime(DateTime.Today);

        // Act
        var exception = Record.Exception(() => DepartmentStartDate.Create(deptStartDate));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void DepartmentStartDate_InvalidData_DefaultDate_Should_ThrowException()
    {
        // Arrange
        DateOnly deptStartDate = new();

        // Act
        var exception = Record.Exception(() => DepartmentStartDate.Create(deptStartDate));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void DepartmentStartDate_CompareEqual()
    {
        // Arrange
        DateOnly deptStartDate1 = DateOnly.FromDateTime(DateTime.Today);
        DateOnly deptStartDate2 = DateOnly.FromDateTime(DateTime.Today);

        // Act
        DepartmentStartDate departmentStartDate1 = DepartmentStartDate.Create(deptStartDate1);
        DepartmentStartDate departmentStartDate2 = DepartmentStartDate.Create(deptStartDate2);

        // Assert
        Assert.Equal(departmentStartDate1, departmentStartDate2);
    }

    [Fact]
    public void DepartmentStartDate_CompareNotEqual()
    {
        // Arrange
        DateOnly deptStartDate1 = new(2023, 11, 1);
        DateOnly deptStartDate2 = new(2021, 11, 1);

        // Act
        DepartmentStartDate departmentStartDate1 = DepartmentStartDate.Create(deptStartDate1);
        DepartmentStartDate departmentStartDate2 = DepartmentStartDate.Create(deptStartDate2);

        // Assert
        Assert.NotEqual(departmentStartDate1, departmentStartDate2);
    }

    [Fact]
    public void DepartmentEndDate_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        DateOnly endDate = new(2023, 11, 13);

        // Act
        var exception = Record.Exception(() => DepartmentEndDate.Create(endDate));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void DepartmentEndDate_ValidData_Null_ShouldNot_ThrowException()
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => DepartmentEndDate.Create(null!));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void DepartmentEndDate_InvalidData_DefaultDate_Should_ThrowException()
    {
        // Arrange
        DateOnly endDate = new();

        // Act
        var exception = Record.Exception(() => DepartmentEndDate.Create(endDate));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void DepartmentEndDate_CompareNotEqual()
    {
        // Arrange
        DateOnly endDate1 = new(2023, 11, 13);
        DateOnly endDate2 = new(2023, 11, 13);

        // Act
        DepartmentEndDate departmentEndDate1 = DepartmentEndDate.Create(endDate1);
        DepartmentEndDate departmentEndDate2 = DepartmentEndDate.Create(endDate2);

        // Assert
        Assert.Equal(departmentEndDate1, departmentEndDate2);
    }

    [Fact]
    public void DepartmentEndDate_CompareEqual()
    {
        // Arrange
        DateOnly endDate1 = new(2023, 11, 13);
        DateOnly endDate2 = new(2022, 11, 13);

        // Act
        DepartmentEndDate departmentEndDate1 = DepartmentEndDate.Create(endDate1);
        DepartmentEndDate departmentEndDate2 = DepartmentEndDate.Create(endDate2);

        // Assert
        Assert.NotEqual(departmentEndDate1, departmentEndDate2);
    }


    [Fact]
    public void EmployerIdentificationNumber_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        string ein = "123456789";

        // Act
        var exception = Record.Exception(() => EmployerIdentificationNumber.Create(ein));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void EmployerIdentificationNumber_InvalidData_WithDash_Should_ThrowException()
    {
        // Arrange
        string ein = "12-345678";

        // Act
        var exception = Record.Exception(() => EmployerIdentificationNumber.Create(ein));

        // Assert
        Assert.NotNull(exception);
    }

    [Theory]
    [InlineData("12345678")]
    [InlineData("1234567")]
    [InlineData("123456")]
    [InlineData("12345")]
    [InlineData("1234")]
    [InlineData("123")]
    [InlineData("12")]
    [InlineData("1")]
    public void EmployerIdentificationNumber_InvalidData_MoreOrLessThan9Digits_Should_ThrowException(string ein)
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => EmployerIdentificationNumber.Create(ein));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void EmployerIdentificationNumber_ShouldEqual()
    {
        // Arrange
        string one = "123456789";
        string two = "123456789";

        // Act
        EmployerIdentificationNumber ein1 = EmployerIdentificationNumber.Create(one);
        EmployerIdentificationNumber ein2 = EmployerIdentificationNumber.Create(two);

        // Assert
        Assert.Equal(ein2, ein1);
    }

    [Fact]
    public void EmployerIdentificationNumber_ShouldNotEqual()
    {
        // Arrange
        string one = "123456789";
        string two = "987654321";

        // Act
        EmployerIdentificationNumber ein1 = EmployerIdentificationNumber.Create(one);
        EmployerIdentificationNumber ein2 = EmployerIdentificationNumber.Create(two);

        // Assert
        Assert.NotEqual(ein2, ein1);
    }

    [Fact]
    public void EmploymentStatus_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        bool status = true;

        // Act
        var exception = Record.Exception(() => EmploymentStatus.Create(status));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void EmploymentStatus_ValidData_ShouldEqual()
    {
        // Arrange
        bool status1 = true;
        bool status2 = true;

        // Act
        EmploymentStatus employmentStatus1 = EmploymentStatus.Create(status1);
        EmploymentStatus employmentStatus2 = EmploymentStatus.Create(status2);

        // Assert
        Assert.Equal(employmentStatus1, employmentStatus2);
    }

    [Fact]
    public void EmploymentStatus_ValidData_ShouldNotEqual()
    {
        // Arrange
        bool status1 = true;
        bool status2 = false;

        // Act
        EmploymentStatus employmentStatus1 = EmploymentStatus.Create(status1);
        EmploymentStatus employmentStatus2 = EmploymentStatus.Create(status2);

        // Assert
        Assert.NotEqual(employmentStatus1, employmentStatus2);
    }

    [Theory]
    [InlineData("m")]
    [InlineData("f")]
    public void Gender_ValidData_ShouldNot_ThrowException(string gender)
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => Gender.Create(gender));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Gender_InvalidData_Should_ThrowException()
    {
        // Arrange
        string gender = "Q";

        // Act
        var exception = Record.Exception(() => Gender.Create(gender));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void Gender_InvalidData_Null_Should_ThrowException()
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => Gender.Create(null!));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void Gender_ShouldEqual()
    {
        // Arrange
        string gender1 = "M";
        string gender2 = "M";

        // Act
        Gender gender_1 = Gender.Create(gender1);
        Gender gender_2 = Gender.Create(gender2);

        // Assert
        Assert.Equal(gender_1, gender_2);
    }

    [Fact]
    public void Gender_ShouldNotEqual()
    {
        // Arrange
        string gender1 = "M";
        string gender2 = "F";

        // Act
        Gender gender_1 = Gender.Create(gender1);
        Gender gender_2 = Gender.Create(gender2);

        // Assert
        Assert.NotEqual(gender_1, gender_2);
    }

    [Fact]
    public void JobTitle_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        string title = "The Main Man";

        // Act
        var exception = Record.Exception(() => JobTitle.Create(title));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void JobTitle_InvalidData__Null_Should_ThrowException()
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => JobTitle.Create(null!));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void JobTitle_InvalidData_TooLong_Should_ThrowException()
    {
        // Arrange
        StringBuilder sb = new("The Main Man") { Length = 51 };

        // Act
        var exception = Record.Exception(() => JobTitle.Create(sb.ToString()));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void JobTitle_ShouldEqual()
    {
        // Arrange
        string title1 = "The Main Man";
        string title2 = "The Main Man";

        // Act
        JobTitle jobTitle1 = JobTitle.Create(title1);
        JobTitle jobTitle2 = JobTitle.Create(title2);

        // Assert
        Assert.Equal(jobTitle1, jobTitle2);
    }

    [Fact]
    public void JobTitle_ShouldNotEqual()
    {
        // Arrange
        string title1 = "The Main Man";
        string title2 = "Hello, World!";

        // Act
        JobTitle jobTitle1 = JobTitle.Create(title1);
        JobTitle jobTitle2 = JobTitle.Create(title2);

        // Assert
        Assert.NotEqual(jobTitle1, jobTitle2);
    }

    [Fact]
    public void Login_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        string login = @"adventure-works\rob0";

        // Act
        var exception = Record.Exception(() => Login.Create(login));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Login_InvalidData_TooLong_Should_ThrowException()
    {
        // Arrange
        StringBuilder sb = new(@"adventure-works\rob0") { Length = 257 };

        // Act
        var exception = Record.Exception(() => Login.Create(sb.ToString()));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void Login_InvalidData_Null_Should_ThrowException()
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => Login.Create(null!));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void Login_ShouldEqual()
    {
        // Arrange
        string one = @"adventure-works\rob0";
        string two = @"adventure-works\rob0";

        // Act
        Login login1 = Login.Create(one);
        Login login2 = Login.Create(two);

        // Assert
        Assert.Equal(login1, login2);
    }

    [Fact]
    public void Login_ShouldNotEqual()
    {
        // Arrange
        string one = @"adventure-works\rob0";
        string two = @"adventure-works\ken0";

        // Act
        Login login1 = Login.Create(one);
        Login login2 = Login.Create(two);

        // Assert
        Assert.NotEqual(login1, login2);
    }

    [Theory]
    [InlineData("m")]
    [InlineData("s")]
    public void MaritalStatus_ValidData_ShouldNot_ThrowException(string status)
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => MaritalStatus.Create(status));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void MaritalStatus_InvalidData_Should_ThrowException()
    {
        // Arrange
        string status = "A";
        // Act
        var exception = Record.Exception(() => MaritalStatus.Create(status));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void MaritalStatus_InvalidData_Null_Should_ThrowException()
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => MaritalStatus.Create(null!));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void MaritalStatus_ShouldEqual()
    {
        // Arrange
        string one = "M";
        string two = "M";

        // Act
        MaritalStatus status1 = MaritalStatus.Create(one);
        MaritalStatus status2 = MaritalStatus.Create(two);

        // Assert
        Assert.Equal(status1, status2);
    }
    [Fact]
    public void MaritalStatus_ShouldNotEqual()
    {
        // Arrange
        string one = "M";
        string two = "S";

        // Act
        MaritalStatus status1 = MaritalStatus.Create(one);
        MaritalStatus status2 = MaritalStatus.Create(two);

        // Assert
        Assert.NotEqual(status1, status2);
    }

    [Theory]
    [InlineData("12345")]
    [InlineData("123456")]
    [InlineData("1234567")]
    [InlineData("12345678")]
    [InlineData("123456789")]
    public void NationalID_ValidData_ShouldNot_ThrowException(string id)
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => NationalID.Create(id));

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("1234")]
    [InlineData("1234567890")]
    public void NationalID_InvalidData_Should_ThrowException(string id)
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => NationalID.Create(id));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void NationalID_InvalidData_Null_Should_ThrowException()
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => NationalID.Create(null!));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void NationalID_ShouldEqual()
    {
        // Arrange
        string id1 = "123456789";
        string id2 = "123456789";

        // Act
        NationalID nationalID1 = NationalID.Create(id1);
        NationalID nationalID2 = NationalID.Create(id2);

        // Assert
        Assert.Equal(nationalID1, nationalID2);
    }

    [Fact]
    public void NationalID_ShouldNotEqual()
    {
        // Arrange
        string id1 = "123456789";
        string id2 = "987654321";

        // Act
        NationalID nationalID1 = NationalID.Create(id1);
        NationalID nationalID2 = NationalID.Create(id2);

        // Assert
        Assert.NotEqual(nationalID1, nationalID2);
    }

    [Fact]
    public void RateOfPay_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        Money money = Money.Create(Currency.Create("USD", "U.S. Dollar"), 6.50M);

        // Act
        var exception = Record.Exception(() => RateOfPay.Create(money));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void RateOfPay_InvalidData_TooHigh_Should_ThrowException()
    {
        // Arrange
        Money money = Money.Create(Currency.Create("USD", "U.S. Dollar"), 200.01M);

        // Act
        var exception = Record.Exception(() => RateOfPay.Create(money));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void RateOfPay_InvalidData_TooLow_Should_ThrowException()
    {
        // Arrange
        Money money = Money.Create(Currency.Create("USD", "U.S. Dollar"), 6.49M);

        // Act
        var exception = Record.Exception(() => RateOfPay.Create(money));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void RateOfPay_InvalidData_NullMoney_Should_ThrowException()
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => RateOfPay.Create(null!));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void RateOfPay_ShouldEqual()
    {
        // Arrange
        Money money1 = Money.Create(Currency.Create("USD", "U.S. Dollar"), 6.50M);
        Money money2 = Money.Create(Currency.Create("USD", "U.S. Dollar"), 6.50M);

        // Act
        RateOfPay rate1 = RateOfPay.Create(money1);
        RateOfPay rate2 = RateOfPay.Create(money2);

        // Assert
        Assert.Equal(rate1, rate2);
    }

    [Fact]
    public void RateOfPay_ShouldNotEqual()
    {
        // Arrange
        Money money1 = Money.Create(Currency.Create("USD", "U.S. Dollar"), 80.00M);
        Money money2 = Money.Create(Currency.Create("USD", "U.S. Dollar"), 100.00M);

        // Act
        RateOfPay rate1 = RateOfPay.Create(money1);
        RateOfPay rate2 = RateOfPay.Create(money2);

        // Assert
        Assert.NotEqual(rate1, rate2);
    }

    [Fact]
    public void ShiftName_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        string shiftName = "Day";

        // Act
        var exception = Record.Exception(() => ShiftName.Create(shiftName));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ShiftName_InvalidData_NameTooLong_Should_ThrowException()
    {
        // Arrange
        StringBuilder sb = new("The Main Man") { Length = 51 };

        // Act
        var exception = Record.Exception(() => ShiftName.Create(sb.ToString()));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void ShiftName_InvalidData_NameIsNull_Should_ThrowException()
    {
        // Arrange

        // Act
        var exception = Record.Exception(() => ShiftName.Create(null!));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void ShiftName_ShouldEqual()
    {
        // Arrange
        string shiftName1 = "Day";
        string shiftName2 = "Day";

        // Act
        ShiftName one = ShiftName.Create(shiftName1);
        ShiftName two = ShiftName.Create(shiftName2);

        // Assert
        Assert.Equal(one, two);
    }

    [Fact]
    public void ShiftName_ShouldNotEqual()
    {
        // Arrange
        string shiftName1 = "Day";
        string shiftName2 = "Night";

        // Act
        ShiftName one = ShiftName.Create(shiftName1);
        ShiftName two = ShiftName.Create(shiftName2);

        // Assert
        Assert.NotEqual(one, two);
    }

    [Fact]
    public void ShiftTime_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        int minutePart = 0;
        int hourPart = 7;

        // Act
        var exception = Record.Exception(() => ShiftTime.Create(hourPart, minutePart));

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(60)]
    public void ShiftTime_InvalidData_MinuteTooHighTooLow_Should_ThrowException(int minute)
    {
        // Arrange
        int hourPart = 7;

        // Act
        var exception = Record.Exception(() => ShiftTime.Create(hourPart, minute));

        // Assert
        Assert.NotNull(exception);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(60)]
    public void ShiftTime_InvalidData_HourTooHighTooLow_Should_ThrowException(int hour)
    {
        // Arrange
        int minutePart = 0;

        // Act
        var exception = Record.Exception(() => ShiftTime.Create(hour, minutePart));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void ShiftTime_ShouldEqual()
    {
        // Arrange

        // Act
        ShiftTime shift1 = ShiftTime.Create(7, 0);
        ShiftTime shift2 = ShiftTime.Create(7, 0);

        // Assert
        Assert.Equal(shift1, shift2);
    }

    [Fact]
    public void ShiftTime_ShouldNotEqual()
    {
        // Arrange

        // Act
        ShiftTime shift1 = ShiftTime.Create(7, 0);
        ShiftTime shift2 = ShiftTime.Create(17, 30);

        // Assert
        Assert.NotEqual(shift1, shift2);
    }

    [Fact]
    public void SickLeave_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        int sickLeaveHours = 10;

        // Act
        var exception = Record.Exception(() => SickLeave.Create(sickLeaveHours));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void SickLeave_InvalidData_SickLeaveHoursTooLow_Should_ThrowException()
    {
        // Arrange
        int sickLeaveHours = -1;

        // Act
        var exception = Record.Exception(() => SickLeave.Create(sickLeaveHours));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void SickLeave_InvalidData_SickLeaveHoursTooHigh_Should_ThrowException()
    {
        // Arrange
        int sickLeaveHours = 121;

        // Act
        var exception = Record.Exception(() => SickLeave.Create(sickLeaveHours));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void SickLeave_ShouldEqual()
    {
        // Arrange
        int sickLeaveHours1 = 12;
        int sickLeaveHours2 = 12;

        // Act
        SickLeave sickLeave1 = SickLeave.Create(sickLeaveHours1);
        SickLeave sickLeave2 = SickLeave.Create(sickLeaveHours2);

        // Assert
        Assert.Equal(sickLeave1, sickLeaveHours2);
    }

    [Fact]
    public void SickLeave_ShouldNotEqual()
    {
        // Arrange
        int sickLeaveHours1 = 12;
        int sickLeaveHours2 = 50;

        // Act
        SickLeave sickLeave1 = SickLeave.Create(sickLeaveHours1);
        SickLeave sickLeave2 = SickLeave.Create(sickLeaveHours2);

        // Assert
        Assert.NotEqual(sickLeave1, sickLeaveHours2);
    }

    [Fact]
    public void Vacation_ValidData_ShouldNot_ThrowException()
    {
        // Arrange
        int vacationHours = 20;

        // Act
        var exception = Record.Exception(() => Vacation.Create(vacationHours));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Vacation_InvalidData_VacationHoursTooLow_ShouldNot_ThrowException()
    {
        // Arrange
        int vacationHours = -41;

        // Act
        var exception = Record.Exception(() => Vacation.Create(vacationHours));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void Vacation_InvalidData_VacationHoursTooHigh_ShouldNot_ThrowException()
    {
        // Arrange
        int vacationHours = -241;

        // Act
        var exception = Record.Exception(() => Vacation.Create(vacationHours));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void Vacation_ShouldEqual()
    {
        // Arrance
        int vacationHours1 = 41;
        int vacationHours2 = 41;

        // Act
        Vacation vacation1 = Vacation.Create(vacationHours1);
        Vacation vacation2 = Vacation.Create(vacationHours2);

        // Assert
        Assert.Equal(vacation1, vacation2);
    }

    [Fact]
    public void Vacation_ShouldNotEqual()
    {
        // Arrance
        int vacationHours1 = 41;
        int vacationHours2 = 0;

        // Act
        Vacation vacation1 = Vacation.Create(vacationHours1);
        Vacation vacation2 = Vacation.Create(vacationHours2);

        // Assert
        Assert.NotEqual(vacation1, vacation2);
    }
}