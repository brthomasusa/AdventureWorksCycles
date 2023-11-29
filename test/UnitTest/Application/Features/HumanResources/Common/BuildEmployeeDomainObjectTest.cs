using AWC.Application.Features.HumanResources.Common;
using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.Shared;
using AWC.UnitTest.Shared.Data;
using AWC.UnitTest.Shared;
using MapsterMapper;

namespace AWC.UnitTest.Application.Features.HumanResources.Common
{
    public class BuildEmployeeDomainObjectTest
    {
        private readonly IMapper _mapper;

        public BuildEmployeeDomainObjectTest()
            => _mapper = AddMapsterForUnitTests.GetMapper();

        [Fact]
        public void BuildEmployeeDomainObject_CreateEmployeeCommand_ConvertToEmployeeDomainObj_ShouldSucceed()
        {
            // Arrange
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();

            // Act
            Result<Employee> result = BuildEmployeeDomainObject.ConvertToGenericCommand(command, _mapper);

            // Assert
            Assert.IsType<Employee>(result.Value);
            Assert.Equal(command.LastName, result.Value.Name.LastName);
        }

        [Fact]
        public void EmployeeDomainObjectBuilder_CreateEmployeeCommand_ShouldHaveConverted_OneDepartmentHistory()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            Result<Employee> result = BuildEmployeeDomainObject.ConvertToGenericCommand(command, _mapper);

            Assert.Single(result.Value.DepartmentHistories!);
        }

        [Fact]
        public void EmployeeDomainObjectBuilder_CreateEmployeeCommand_ShouldHaveConverted_OnePayHistory()
        {
            // Arrange
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();

            // Act
            Result<Employee> result = BuildEmployeeDomainObject.ConvertToGenericCommand(command, _mapper);

            // Assert
            Assert.Single(result.Value.PayHistories!);
        }

        [Fact]
        public void EmployeeDomainObjectBuilder_CreateEmployeeCommand_ShouldHaveConverted_OneEmployeeAddress()
        {
            // Arrange
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();

            // Act
            Result<Employee> result = BuildEmployeeDomainObject.ConvertToGenericCommand(command, _mapper);
            Address? address = result.Value.Addresses.SingleOrDefault();

            // Assert
            Assert.NotNull(address);
            Assert.Equal("123 street", address.Location.AddressLine1);
        }

        [Fact]
        public void EmployeeDomainObjectBuilder_CreateEmployeeCommand_ShouldHaveConverted_OneEmployeeEmailAddress()
        {
            // Arrange
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();

            // Act
            Result<Employee> result = BuildEmployeeDomainObject.ConvertToGenericCommand(command, _mapper);
            PersonEmailAddress? emailAddress = result.Value.EmailAddresses.SingleOrDefault();

            // Assert
            Assert.NotNull(emailAddress);
            Assert.Equal("johnny@adventure-works.com", emailAddress.EmailAddress);
        }

        [Fact]
        public void EmployeeDomainObjectBuilder_CreateEmployeeCommand_ShouldHaveConverted_OneEmployeePhone()
        {
            // Arrange
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();

            // Act
            Result<Employee> result = BuildEmployeeDomainObject.ConvertToGenericCommand(command, _mapper);
            PersonPhone? phone = result.Value.Telephones.SingleOrDefault();

            // Assert
            Assert.NotNull(phone);
            Assert.Equal("555-555-5555", phone.Telephone);
        }

        [Fact]
        public void BuildEmployeeDomainObject_UpdateEmployeeCommand_ConvertToEmployeeDomainObj_ShouldSucceed()
        {
            // Arrange
            UpdateEmployeeCommand command = EmployeeTestData.GetUpdateEmployeeCommand_ValidData();

            // Act
            Result<Employee> result = BuildEmployeeDomainObject.ConvertToGenericCommand(command, _mapper);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.IsType<Employee>(result.Value);
            Assert.Equal(command.LastName, result.Value.Name.LastName);
        }
    }
}