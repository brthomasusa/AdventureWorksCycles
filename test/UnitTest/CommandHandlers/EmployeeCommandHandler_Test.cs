using AWC.Application.Features.HumanResources.Common;
using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Core.HumanResources;
using AWC.Core.Shared;
using AWC.UnitTest.Data;
using MapsterMapper;

namespace AWC.UnitTest.CommandHandlers
{
    public class EmployeeCommandHandler_Test
    {
        private readonly IMapper _mapper;

        public EmployeeCommandHandler_Test()
            => _mapper = AddMapsterForUnitTests.GetMapper();

        [Fact]
        public void BuildEmployeeDomainObject_Build_CreateEmployeeCommand_ShouldSucceed()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            Assert.True(result.IsSuccess);
            Assert.IsType<Employee>(result.Value);
        }

        [Fact]
        public void BuildEmployeeDomainObject_Build_CreateEmployeeCommand_EmptyNationalID_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_EmptyNationalID();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public void BuildEmployeeDomainObject_Build_CreateEmployeeCommand_DefaultDeptHistoryStartDate_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_DefaultDeptHistoryStartDate();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public void BuildEmployeeDomainObject_Build_CreateEmployeeCommand_DefaultPayHistoryRateChangeDate_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_DefaultPayHistoryRateChangeDate();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public void BuildEmployeeDomainObject_Build_CreateEmployeeCommand_EmptyEmailAddress_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_EmptyEmailAddress();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public void BuildEmployeeDomainObject_Build_CreateEmployeeCommand_EmptyPhoneNumber_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_EmptyPhoneNumber();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public void BuildEmployeeDomainObject_Build_CreateEmployeeCommand_EmptyAddressLine1_ShouldFail()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_EmptyAddressLine1();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            Assert.True(result.IsFailure);
        }

        [Fact]
        public void EmployeeDomainObjectBuilder_Build_ShouldHave_OneDepartmentHistory()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            Assert.Single(result.Value.DepartmentHistories!);
        }

        [Fact]
        public void EmployeeDomainObjectBuilder_Build_ShouldHave_OnePayHistory()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            Assert.Single(result.Value.PayHistories!);
        }

        [Fact]
        public void EmployeeDomainObjectBuilder_Build_ShouldHave_OneEmployeeAddress()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            Address? address = result.Value.Addresses.SingleOrDefault();

            Assert.NotNull(address);
            Assert.Equal("123 street", address.Location.AddressLine1);
        }

        [Fact]
        public void EmployeeDomainObjectBuilder_Build_ShouldHave_OneEmployeeEmailAddress()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            PersonEmailAddress? emailAddress = result.Value.EmailAddresses.SingleOrDefault();

            Assert.NotNull(emailAddress);
            Assert.Equal("johnny@adventure-works.com", emailAddress.EmailAddress);
        }

        [Fact]
        public void EmployeeDomainObjectBuilder_Build_ShouldHave_OneEmployeePhone()
        {
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            PersonPhone? phone = result.Value.Telephones.SingleOrDefault();

            Assert.NotNull(phone);
            Assert.Equal("555-555-5555", phone.Telephone);
        }

        [Fact]
        public void BuildEmployeeDomainObject_Build_UpdateEmployeeCommand_ShouldSucceed()
        {
            UpdateEmployeeCommand command = EmployeeTestData.GetUpdateEmployeeCommand_ValidData();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);

            Assert.True(result.IsSuccess);
            Assert.IsType<Employee>(result.Value);
        }
    }
}