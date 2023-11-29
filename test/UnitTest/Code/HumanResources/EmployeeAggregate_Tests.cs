using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Core.Entities.Shared;
using AWC.Core.Entities.Shared.EntityIDs;
using AWC.Core.Enums;
using AWC.SharedKernel.Base;
using AWC.UnitTest.Shared.Data;

namespace AWC.UnitTest.Code.UnitTests.HumanResources;

public class EmployeeAggregate_Tests
{
    [Fact]
    public void DepartmentHistory_Create_ValidData_NullEndDate_ShouldReturn_Success()
    {
        // Arrang

        // Act
        Result<DepartmentHistory> result = DepartmentHistory.Create
        (
            new DepartmentHistoryID(1), new DepartmentID(1), new ShiftID(1), new DateOnly(2023, 11, 17), null
        );

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void DepartmentHistory_Create_ValidData_NonNullEndDate_ShouldReturn_Success()
    {
        // Arrange

        // Act
        Result<DepartmentHistory> result = DepartmentHistory.Create
        (
            new DepartmentHistoryID(1), new DepartmentID(1), new ShiftID(1), new DateOnly(2023, 11, 17), new DateOnly(2023, 11, 17)
        );

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void DepartmentHistory_Create_InvalidData_StartDateAfterEndDate_ShouldReturn_Failure()
    {
        // Arrang

        // Act
        Result<DepartmentHistory> result = DepartmentHistory.Create
        (
            new DepartmentHistoryID(1), new DepartmentID(1), new ShiftID(1), new DateOnly(2023, 11, 17), new DateOnly(2023, 11, 16)
        );

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void PayHistory_Create_ValidData_ShouldReturn_Success()
    {
        // Arrange

        // Act
        Result<PayHistory> result = PayHistory.Create(new PayHistoryID(1), new DateTime(2023, 11, 17), 40.00M, PayFrequency.Monthly);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void PayHistory_Create_InvalidData_DefaultDateForRateChange_ShouldReturn_Failure()
    {
        // Arrange

        // Act
        Result<PayHistory> result = PayHistory.Create(new PayHistoryID(1), new DateTime(), 40.00M, PayFrequency.Monthly);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Theory]
    [InlineData(6.49)]
    [InlineData(200.01)]
    public void PayHistory_Create_InvalidData_RateTooLowAndTooHigh_ShouldReturn_Failure(decimal rate)
    {
        // Arrange

        // Act
        Result<PayHistory> result = PayHistory.Create(new PayHistoryID(1), new DateTime(), rate, PayFrequency.Monthly);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Address_Create_ValidData_ShouldReturn_Success()
    {
        // Arrange

        // Act
        Result<Address> result = Address.Create(new AddressID(1), AddressType.Home, "123 Main Street", "Apt 1", "Dallas", 73, "75231");

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Address_Create_InvalidData_NullLine1_ShouldReturn_Failure()
    {
        // Arrange

        // Act
        Result<Address> result = Address.Create(new AddressID(1), AddressType.Home, null!, "Apt 1", "Dallas", 73, "75231");

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Address_Update_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<Address> address = Address.Create(new AddressID(1), AddressType.Home, "123 Main Street", "Apt 1", "Dallas", 73, "75231");

        // Act
        Result<Address> result = address.Value.Update(AddressType.Home, "123 Main Street", "Apt 1", "Dallas", 73, "75231");

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Address_Update_InvalidData_NullLine1_ShouldReturn_Failure()
    {
        // Arrange
        Result<Address> address = Address.Create(new AddressID(1), AddressType.Home, "123 Main Street", "Apt 1", "Dallas", 73, "75231");

        // Act
        Result<Address> result = address.Value.Update(AddressType.Home, null!, "Apt 1", "Dallas", 73, "75231");

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void PersonEmailAddress_Create_ValidData_ShouldReturn_Success()
    {
        // Arrange

        // Act
        Result<PersonEmailAddress> emailAddress = PersonEmailAddress.Create(new PersonEmailAddressID(1), "j.doe@adventureworks.com");

        // Assert
        Assert.True(emailAddress.IsSuccess);
    }

    [Fact]
    public void PersonEmailAddress_Create_InvalidData_NullEmail_ShouldReturn_Failure()
    {
        // Arrange

        // Act
        Result<PersonEmailAddress> emailAddress = PersonEmailAddress.Create(new PersonEmailAddressID(1), null!);

        // Assert
        Assert.True(emailAddress.IsFailure);
    }

    [Fact]
    public void PersonEmailAddress_Update_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<PersonEmailAddress> emailAddress = PersonEmailAddress.Create(new PersonEmailAddressID(1), "j.doe@adventureworks.com");

        // Act
        Result<PersonEmailAddress> result = emailAddress.Value.UpdateEmailAddress("j.doe@adventureworks.com");

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void PersonEmailAddress_Update_InvalidData_NullEmailAddress_ShouldReturn_Failure()
    {
        // Arrange
        Result<PersonEmailAddress> emailAddress = PersonEmailAddress.Create(new PersonEmailAddressID(1), "j.doe@adventureworks.com");

        // Act
        Result<PersonEmailAddress> result = emailAddress.Value.UpdateEmailAddress(null!);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void PersonPhone_Create_ValidData_ShouldReturn_Success()
    {
        // Arrange

        // Act
        Result<PersonPhone> phoneResult = PersonPhone.Create(new PersonPhoneID(1), PhoneNumberType.Home, "555-555-5555");

        // Assert
        Assert.True(phoneResult.IsSuccess);
    }

    [Fact]
    public void PersonPhone_Create_InvalidData_NullPhoneNumber_ShouldReturn_Failure()
    {
        // Arrange

        // Act
        Result<PersonPhone> phoneResult = PersonPhone.Create(new PersonPhoneID(1), PhoneNumberType.Home, null!);

        // Assert
        Assert.True(phoneResult.IsFailure);
    }

    [Fact]
    public void PersonPhone_Update_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<PersonPhone> phoneResult = PersonPhone.Create(new PersonPhoneID(1), PhoneNumberType.Home, "555-555-5555");

        // Act
        Result<PersonPhone> result = phoneResult.Value.Update(PhoneNumberType.Cell, "214-878-0011");

        // Assert
        Assert.True(phoneResult.IsSuccess);
    }

    [Fact]
    public void PersonPhone_Update_InvalidData_ShouldReturn_Failure()
    {
        // Arrange
        Result<PersonPhone> phoneResult = PersonPhone.Create(new PersonPhoneID(1), PhoneNumberType.Home, "555-555-5555");

        // Act
        Result<PersonPhone> result = phoneResult.Value.Update(PhoneNumberType.Cell, null!);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_Create_ValidData_ShouldReturn_Success()
    {
        Result<Employee> result = EmployeeTestData.GetValidEmployee();

        Assert.True(result.IsSuccess);
    }

    [Theory]
    [InlineData("XY", "123456789", "01-01-2000", "01-01-1968")]
    [InlineData("EM", "1234", "01-01-2000", "01-01-1968")]
    [InlineData("EM", "123456789", "01-01-2007", "01-01-1968")]
    [InlineData("EM", "123456789", "01-01-2000", "01-01-1929")]
    public void Employee_Create_InvalidData_ShouldReturn_Failure(string personType, string nationalID, string birthday, string hireDate)
    {
        // Arrange

        // Act
        Result<Employee> result = Employee.Create
        (
            new EmployeeID(1),
            personType,
            NameStyle.Western,
            "Mr.",
            "John",
            "Doe",
            "J",
            null,
            new EmployeeID(0),
            nationalID,
            @"adventure-works\johnny0",
            "The Man",
            DateOnly.Parse(birthday),
            "M",
            "M",
            DateOnly.Parse(hireDate),
            true,
            5,
            1,
            true
        );

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_Update_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();

        // Act
        Result<Employee> result = employee.Value.Update
        (
            "EM",
            NameStyle.Western,
            "Mr.",
            "John",
            "Doe",
            "J",
            null!,
            0,
            "13232177",
            @"adventure-works\johnny0",
            "The Man",
            new DateOnly(2003, 1, 17),
            "M",
            "M",
            new DateOnly(2020, 1, 28),
            true,
            5,
            1,
            true
        );

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Theory]
    [InlineData("XY", "123456789", "01-01-2000", "01-01-1968")]
    [InlineData("EM", "1234", "01-01-2000", "01-01-1968")]
    [InlineData("EM", "123456789", "01-01-2007", "01-01-1968")]
    [InlineData("EM", "123456789", "01-01-2000", "01-01-1929")]
    public void Employee_Update_InvalidData_ShouldReturn_Failure(string personType, string nationalID, string birthday, string hireDate)
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();

        // Act
        Result<Employee> result = employee.Value.Update
        (
            personType,
            NameStyle.Western,
            "Mr.",
            "John",
            "Doe",
            "J",
            null!,
            0,
            nationalID,
            @"adventure-works\johnny0",
            "The Man",
            DateOnly.Parse(birthday),
            "M",
            "M",
            DateOnly.Parse(hireDate),
            true,
            5,
            1,
            true
        );

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_AddDepartmentHistory_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();

        // Act
        Result<DepartmentHistory> result = employee.Value.AddDepartmentHistory(new DepartmentHistoryID(0), new DepartmentID(1), new ShiftID(1), new DateOnly(2023, 11, 18), null);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Employee_AddDepartmentHistory_InvalidData_DupePayHistory_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<DepartmentHistory> result = employee.Value.AddDepartmentHistory(new DepartmentHistoryID(0), new DepartmentID(1), new ShiftID(1), new DateOnly(2023, 11, 18), null);

        // Act
        result = employee.Value.AddDepartmentHistory(new DepartmentHistoryID(0), new DepartmentID(1), new ShiftID(1), new DateOnly(2023, 11, 18), null);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_AddPayHistory_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();

        // Act
        Result<PayHistory> result = employee.Value.AddPayHistory(new PayHistoryID(0), new DateTime(2023, 11, 18), 20.00M, PayFrequency.Monthly);

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Theory]
    [InlineData(6.49)]
    [InlineData(200.01)]
    public void Employee_AddPayHistory_InvalidData__ShouldReturn_Success(decimal rate)
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();

        // Act
        Result<PayHistory> result = employee.Value.AddPayHistory(new PayHistoryID(0), new DateTime(2023, 11, 18), rate, PayFrequency.Monthly);

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_AddAddress_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();

        // Act
        Result<Address> result = employee.Value.AddAddress(new AddressID(1), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(EntityStatus.Added, result.Value.EntityStatus);
    }

    [Fact]
    public void Employee_AddAddress_ValidData_OnlyAddressTypeIsDifferent_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<Address> address = employee.Value.AddAddress(new AddressID(0), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");

        // Act
        Result<Address> result = employee.Value.AddAddress(new AddressID(0), AddressType.Archive, "123 Main", "Apt 1", "Austin", 73, "78880");

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(EntityStatus.Added, result.Value.EntityStatus);
    }

    [Fact]
    public void Employee_AddAddress_InvalidData_NonLine1_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();

        // Act
        Result<Address> result = employee.Value.AddAddress(new AddressID(1), AddressType.Home, null!, "Apt 1", "Austin", 73, "78880");

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_AddAddress_InvalidData_DupeNonZeroAddressID_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<Address> address1 = employee.Value.AddAddress(new AddressID(1), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");

        // Act
        Result<Address> result = employee.Value.AddAddress(new AddressID(1), AddressType.Home, "321 Main", "Apt 1", "Austin", 73, "78880");

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_AddAddress_InvalidData_DupeAddress_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<Address> address1 = employee.Value.AddAddress(new AddressID(1), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");

        // Act
        Result<Address> result = employee.Value.AddAddress(new AddressID(2), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_AddAddress_InvalidData_DupeNewAddresses_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<Address> address1 = employee.Value.AddAddress(new AddressID(0), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");

        // Act
        Result<Address> result = employee.Value.AddAddress(new AddressID(0), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_UpdateAddress_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<Address> address = employee.Value.AddAddress(new AddressID(1), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");
        address = employee.Value.AddAddress(new AddressID(2), AddressType.Home, "123 Main", "Apt 2", "Austin", 73, "78880");

        // Act
        Result<Address> result = employee.Value.UpdateAddress(new AddressID(2), AddressType.Home, "123 1st Street", "Apt 2", "Austin", 73, "78880");

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Employee_UpdateAddress_InvalidData_BadAddressID_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<Address> address = employee.Value.AddAddress(new AddressID(1), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");
        address = employee.Value.AddAddress(new AddressID(2), AddressType.Home, "123 Main", "Apt 2", "Austin", 73, "78880");

        // Act
        Result<Address> result = employee.Value.UpdateAddress(new AddressID(3), AddressType.Home, "123 1st Street", "Apt 2", "Austin", 73, "78880");

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_UpdateAddress_InvalidData_DuplicateAddress_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<Address> address1 = employee.Value.AddAddress(new AddressID(1), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");
        address1.Value.EntityStatus = EntityStatus.Modified;

        Result<Address> address2 = employee.Value.AddAddress(new AddressID(2), AddressType.Home, "123 1st Street", "Apt 2", "Austin", 73, "78880");
        address2.Value.EntityStatus = EntityStatus.Modified;


        // Act
        Result<Address> result = employee.Value.UpdateAddress(new AddressID(2), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_UpdateAddress_InvalidData_MeaninglessUpdate_ShouldReturn_Success()
    {
        // A meaningless update is updating an address with the values it already has
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<Address> address = employee.Value.AddAddress(new AddressID(1), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");
        address = employee.Value.AddAddress(new AddressID(2), AddressType.Home, "123 1st Street", "Apt 2", "Austin", 73, "78880");

        // Act
        Result<Address> result = employee.Value.UpdateAddress(new AddressID(1), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Employee_DeleteAddress_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<Address> address = employee.Value.AddAddress(new AddressID(1), AddressType.Home, "123 Main", "Apt 1", "Austin", 73, "78880");

        // Act
        Result result = employee.Value.DeleteAddress(new AddressID(1));

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Employee_AddPersonEmailAddress_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();

        // Act
        Result<PersonEmailAddress> result = employee.Value.AddEmailAddress(new PersonEmailAddressID(0), @"billy.bob@adventureworks.com");

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Employee_AddPersonEmailAddress_InvalidData_DuplicateID_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<PersonEmailAddress> email1 = employee.Value.AddEmailAddress(new PersonEmailAddressID(1), @"billy.bob@adventureworks.com");

        // Act
        Result<PersonEmailAddress> email2 = employee.Value.AddEmailAddress(new PersonEmailAddressID(1), @"silly.bob@adventureworks.com");

        // Assert
        Assert.True(email2.IsFailure);
    }

    [Fact]
    public void Employee_AddPersonEmailAddress_InvalidData_DuplicateEmailAddress_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<PersonEmailAddress> email1 = employee.Value.AddEmailAddress(new PersonEmailAddressID(1), @"billy.bob@adventureworks.com");

        // Act
        Result<PersonEmailAddress> email2 = employee.Value.AddEmailAddress(new PersonEmailAddressID(2), @"BILLY.bOb@adventureworks.com");

        // Assert
        Assert.True(email2.IsFailure);
    }

    [Fact]
    public void Employee_DeletePersonEmailAddress_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<PersonEmailAddress> email1 = employee.Value.AddEmailAddress(new PersonEmailAddressID(1), @"billy.bob@adventureworks.com");

        // Act
        Result result = employee.Value.DeleteEmailAddress(new PersonEmailAddressID(1));

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Employee_DeletePersonEmailAddress_InvalidData_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<PersonEmailAddress> email1 = employee.Value.AddEmailAddress(new PersonEmailAddressID(1), @"billy.bob@adventureworks.com");

        // Act
        Result result = employee.Value.DeleteEmailAddress(new PersonEmailAddressID(11));

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_AddPersonPhone_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();

        // Act
        Result<PersonPhone> result = employee.Value.AddPhoneNumber(new PersonPhoneID(1), PhoneNumberType.Home, "555-555-5555");

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Employee_AddPersonPhone_ValidData_DuplicateZeroID_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<PersonPhone> result = employee.Value.AddPhoneNumber(new PersonPhoneID(0), PhoneNumberType.Home, "555-555-5555");

        // Act
        result = employee.Value.AddPhoneNumber(new PersonPhoneID(0), PhoneNumberType.Home, "214-555-5555");

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Employee_AddPersonPhone_InvalidData_DuplicatePhoneNumber_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<PersonPhone> result = employee.Value.AddPhoneNumber(new PersonPhoneID(1), PhoneNumberType.Home, "555-555-5555");

        // Act
        result = employee.Value.AddPhoneNumber(new PersonPhoneID(0), PhoneNumberType.Home, "555-555-5555");

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_AddPersonPhone_InvalidData_DuplicateNonZeroID_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<PersonPhone> result = employee.Value.AddPhoneNumber(new PersonPhoneID(1), PhoneNumberType.Home, "555-555-5555");

        // Act
        result = employee.Value.AddPhoneNumber(new PersonPhoneID(1), PhoneNumberType.Home, "214-555-5555");

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_UpdatePersonPhone_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<PersonPhone> result = employee.Value.AddPhoneNumber(new PersonPhoneID(1), PhoneNumberType.Home, "555-555-5555");

        // Act
        result = employee.Value.UpdatePhoneNumber(new PersonPhoneID(1), PhoneNumberType.Home, "817-555-5555");

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Employee_UpdatePersonPhone_InvalidData_DuplicatePhoneNumber_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<PersonPhone> result = employee.Value.AddPhoneNumber(new PersonPhoneID(1), PhoneNumberType.Home, "555-555-5555");
        result = employee.Value.AddPhoneNumber(new PersonPhoneID(2), PhoneNumberType.Cell, "817-555-5555");

        // Act
        result = employee.Value.UpdatePhoneNumber(new PersonPhoneID(1), PhoneNumberType.Cell, "817-555-5555");

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void Employee_DeletePersonPhone_ValidData_ShouldReturn_Success()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<PersonPhone> telephone = employee.Value.AddPhoneNumber(new PersonPhoneID(1), PhoneNumberType.Home, "555-555-5555");

        // Act
        Result result = employee.Value.DeletePhoneNumber(new PersonPhoneID(1));

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Employee_DeletePersonPhone_InvalidData_InvalidID_ShouldReturn_Failure()
    {
        // Arrange
        Result<Employee> employee = EmployeeTestData.GetValidEmployee();
        Result<PersonPhone> telephone = employee.Value.AddPhoneNumber(new PersonPhoneID(1), PhoneNumberType.Home, "555-555-5555");

        // Act
        Result result = employee.Value.DeletePhoneNumber(new PersonPhoneID(11));

        // Assert
        Assert.True(result.IsFailure);
    }

}