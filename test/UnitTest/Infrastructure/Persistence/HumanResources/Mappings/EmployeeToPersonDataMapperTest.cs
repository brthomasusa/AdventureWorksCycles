using AWC.Core.Entities.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.Infrastructure.Persistence.Mappings.HumanResources;
using AWC.UnitTest.Shared;
using AWC.UnitTest.Shared.Data;
using MapsterMapper;

namespace AWC.UnitTest.Infrastructure.Persistence.HumanResources.Mappings
{
    public class EmployeeToPersonDataMapperTest
    {
        private readonly Employee _employee;
        private readonly IMapper _mapper;

        public EmployeeToPersonDataMapperTest()
        {
            PersonDataModel person = PersonDataModelTestData.GetPersonDataModel();
            PersonDataModelToEmployeeDomainModelMapper dataMapper = new();
            Result<Employee> employee = dataMapper.Map(person);
            _employee = employee.Value;
            _mapper = AddMapsterForUnitTests.GetMapper();
        }

        [Fact]
        public void EmployeeDomainModelToPersonDataModelMapper_Map_ShouldReturn_PersonDataModel_Without_NavProperties()
        {
            // Arrange
            EmployeeDomainModelToPersonDataModelMapper modelMapper = new(_mapper);

            // Act
            Result<PersonDataModel> person = modelMapper.Map(_employee);

            // Assert
            Assert.True(person.IsSuccess);
        }

        [Fact]
        public void EmployeeDomainModelToPersonDataModelMapper_Map_ShouldReturn_PersonDataModel_With_EmployeeDataModel()
        {
            // Arrange
            EmployeeDomainModelToPersonDataModelMapper modelMapper = new(_mapper);

            // Act
            Result<PersonDataModel> person = modelMapper.Map(_employee);

            // Assert
            Assert.NotNull(person.Value.Employee);
            Assert.Equal(_employee.Name.LastName, person.Value.LastName);
        }

        [Fact]
        public void EmployeeDomainModelToPersonDataModelMapper_Map_ShouldReturn_PersonDataModel_With_3PayHistories()
        {
            // Arrange
            EmployeeDomainModelToPersonDataModelMapper modelMapper = new(_mapper);

            // Act
            Result<PersonDataModel> person = modelMapper.Map(_employee);

            // Assert
            Assert.NotNull(person.Value.Employee);
            Assert.Equal(3, person.Value.Employee.PayHistories.Count);
        }

        [Fact]
        public void EmployeeDomainModelToPersonDataModelMapper_Map_ShouldReturn_PersonDataModel_With_2DeptHistories()
        {
            // Arrange
            EmployeeDomainModelToPersonDataModelMapper modelMapper = new(_mapper);

            // Act
            Result<PersonDataModel> person = modelMapper.Map(_employee);

            // Assert
            Assert.NotNull(person.Value.Employee);
            Assert.Equal(2, person.Value.Employee.DepartmentHistories.Count);
        }

        [Fact]
        public void EmployeeDomainModelToPersonDataModelMapper_Map_ShouldReturn_PersonDataModel_With_1EmailAddress()
        {
            // Arrange
            EmployeeDomainModelToPersonDataModelMapper modelMapper = new(_mapper);

            // Act
            Result<PersonDataModel> person = modelMapper.Map(_employee);

            // Assert
            Assert.Single(person.Value.EmailAddresses);
        }

        [Fact]
        public void EmployeeDomainModelToPersonDataModelMapper_Map_ShouldReturn_PersonDataModel_With_1PersonPhone()
        {
            // Arrange
            EmployeeDomainModelToPersonDataModelMapper modelMapper = new(_mapper);

            // Act
            Result<PersonDataModel> person = modelMapper.Map(_employee);

            // Assert
            Assert.Single(person.Value.Telephones);
        }

        [Fact]
        public void EmployeeDomainModelToPersonDataModelMapper_Map_ShouldReturn_PersonDataModel_With_1BusinessEntityAddress()
        {
            // Arrange
            EmployeeDomainModelToPersonDataModelMapper modelMapper = new(_mapper);

            // Act
            Result<PersonDataModel> person = modelMapper.Map(_employee);

            // Assert
            Assert.Single(person.Value.BusinessEntityAddresses);
            Assert.NotNull(person.Value.BusinessEntityAddresses.FirstOrDefault());
        }


    }
}

