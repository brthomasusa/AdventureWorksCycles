#pragma warning disable CS8604

using AWC.SharedKernel.Guards;

namespace AWC.UnitTest.SharedKernel;
public class GuardClauses_Test
{
    [Fact]
    public void GuardClauseExtensions_NullOrEmpty_ShouldNotThrow_Exception()
    {
        // Arrange
        string? notNullString = "Hello, world";

        // Act
        var exception = Record.Exception(() => Guard.Against.NullOrEmpty(notNullString, "ParameterName"));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void GuardClauseExtensions_NullOrEmpty_ShouldThrow_Exception()
    {
        // Arrange
        string? nullString = null;

        // Act
        var exception = Record.Exception(() => Guard.Against.NullOrEmpty(nullString, "TestString"));

        // Assert        
        Assert.NotNull(exception);
    }

    [Fact]
    public void GuardClauseExtensions_LengthGreaterThan_ShouldNotThrow_Exception()
    {
        // Arrange
        string? input = "Hello, world";

        // Act
        var exception = Record.Exception(() => Guard.Against.LengthGreaterThan(input, 20));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void GuardClauseExtensions_LengthGreaterThan_ShouldThrow_Exception_WithDefaultMessage()
    {
        // Arrange
        string lastName = "Hello, world, Hello, world, Hello, world";

        // Act
        var exception = Record.Exception(() => Guard.Against.LengthGreaterThan(lastName, 20));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("'lastName' length must be less than or equal to 20 characters.", exception.Message);
    }

    [Fact]
    public void GuardClauseExtensions_LengthGreaterThan_ShouldThrow_Exception_WithCustomMessage()
    {
        // Arrange
        string lastName = "Hello, world, Hello, world, Hello, world";
        string message = "lastName exceeds twenty characters.";

        // Act
        var exception = Record.Exception(() => Guard.Against.LengthGreaterThan(lastName, 20, message));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void GuardClauseExtensions_DefaultDateTime_ShouldNotThrow_Exception()
    {
        // Arrange
        DateTime rateChangeDate = new DateTime(2023, 10, 26, 0, 0, 0, DateTimeKind.Local);

        // Act
        var exception = Record.Exception(() => Guard.Against.DefaultDateTime(rateChangeDate));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void GuardClauseExtensions_DefaultDateTime_ShouldThrow_Exception()
    {
        // Arrange
        DateTime rateChangeDate = new DateTime();

        // Act
        var exception = Record.Exception(() => Guard.Against.DefaultDateTime(rateChangeDate));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void GuardClauseExtensions_Int_LessThan_ShouldNotThrow_Exception()
    {
        // Arrange
        int minimumInventoryLevel = 50;

        // Act
        var exception = Record.Exception(() => Guard.Against.LessThan(minimumInventoryLevel, 10));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void GuardClauseExtensions_Int_LessThan_ShouldThrow_Exception()
    {
        // Arrange
        int minimumInventoryLevel = 5;

        // Act
        var exception = Record.Exception(() => Guard.Against.LessThan(minimumInventoryLevel, 10));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void GuardClauseExtensions_Decimal_LessThan_ShouldNotThrow_Exception()
    {
        // Arrange
        decimal widgetPrice = 5.00M;

        // Act
        var exception = Record.Exception(() => Guard.Against.LessThan(widgetPrice, 4.99M));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void GuardClauseExtensions_Decimal_LessThan_ShouldThrow_Exception()
    {
        // Arrange
        decimal widgetPrice = 5.00M;

        // Act
        var exception = Record.Exception(() => Guard.Against.LessThan(widgetPrice, 9.99M));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void GuardClauseExtensions_Int_GreaterThan_ShouldNotThrow_Exception()
    {
        // Arrange
        int maxInventoryLevel = 50;

        // Act
        var exception = Record.Exception(() => Guard.Against.GreaterThan(maxInventoryLevel, 51));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void GuardClauseExtensions_Int_GreaterThan_ShouldThrow_Exception()
    {
        // Arrange
        int maxInventoryLevel = 50;

        // Act
        var exception = Record.Exception(() => Guard.Against.GreaterThan(maxInventoryLevel, 49));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void GuardClauseExtensions_Decimal_GreaterThan_ShouldNotThrow_Exception()
    {
        // Arrange
        decimal maxInventoryLevel = 50M;

        // Act
        var exception = Record.Exception(() => Guard.Against.GreaterThan(maxInventoryLevel, 50M));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void GuardClauseExtensions_Decimal_GreaterThan_ShouldThrow_Exception()
    {
        // Arrange
        decimal maxInventoryLevel = 50.01M;

        // Act
        var exception = Record.Exception(() => Guard.Against.GreaterThan(maxInventoryLevel, 50M));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void GuardClauseExtensions_GreaterThanTwoDecimalPlaces_ShouldNotThrow_Exception()
    {
        // Arrange
        decimal itemPrice = 50.01M;

        // Act
        var exception = Record.Exception(() => Guard.Against.GreaterThanTwoDecimalPlaces(itemPrice));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void GuardClauseExtensions_GreaterThanTwoDecimalPlaces_ShouldThrow_Exception()
    {
        // Arrange
        decimal itemPrice = 50.011M;    // 50.010M will pass.

        // Act
        var exception = Record.Exception(() => Guard.Against.GreaterThanTwoDecimalPlaces(itemPrice));

        // Assert
        Assert.NotNull(exception);
    }

    [Fact]
    public void GuardClauseExtensions_InvalidUrl_ShouldNotThrow_Exception()
    {
        // Arrange
        string validUrl = "http://microsoft.com";

        // Act
        var exception = Record.Exception(() => Guard.Against.InvalidUrl(validUrl));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void GuardClauseExtensions_InvalidUrl_ShouldThrow_Exception()
    {
        // Arrange
        string invalidUrl = "://microsoft.com";  // There are so many invalid urls that can get through this!!

        // Act
        var exception = Record.Exception(() => Guard.Against.InvalidUrl(invalidUrl));

        // Assert
        Assert.NotNull(exception);
    }
}