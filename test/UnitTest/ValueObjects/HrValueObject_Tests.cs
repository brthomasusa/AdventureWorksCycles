using AWC.Core.HumanResources.ValueObjects;

namespace AWC.UnitTest.ValueObjects;

public class HrValueObject_Tests
{
    [Fact]
    public void DateOfBirth_Create_ValidData_ShouldSucceed()
    {
        DateOnly birthDate = new(2000, 6, 12);
        var exception = Record.Exception(() => DateOfBirth.Create(birthDate));
        Assert.Null(exception);
    }

    [Fact]
    public void DateOfBirth_Create_UnderAge_ShouldFail()
    {
        DateOnly birthDate = new(2006, 6, 12);
        var exception = Record.Exception(() => DateOfBirth.Create(birthDate));
        Assert.NotNull(exception);
    }

    [Fact]
    public void DateOfBirth_Create_OverAgeLimit_ShouldFail()
    {
        DateOnly birthDate = new(1929, 12, 31);
        var exception = Record.Exception(() => DateOfBirth.Create(birthDate));
        Assert.NotNull(exception);
    }
}