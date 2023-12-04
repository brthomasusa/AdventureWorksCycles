using AWC.Core.Entities.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.Mappings.HumanResources;
using AWC.UnitTest.Shared.Data;
using AWC.Infrastructure.Persistence.DataModels.Person;

namespace AWC.UnitTest.Infrastructure.Persistence.HumanResources.Mappings
{
    public class PersonToEmployeeDataMapperTest
    {
        [Fact]
        public void EmployeeAggregateDataMapper_Map_ShouldReturn_EmployeeAggregateRoot_Without_ChildEntities()
        {
            // Arrange
            PersonDataModel person = PersonDataModelTestData.GetPersonDataModel();
            PersonDataModelToEmployeeDomainModelMapper dataMapper = new();

            // Act
            Result<Employee> employee = dataMapper.Map(person);

            // Assert
            Assert.True(employee.IsSuccess);
        }

        [Fact]
        public void PersonDataModelToEmployeeDomainModelMapper_Map_ShouldReturn_EmployeeAggregateRoot_WithTwo_DeptHistories()
        {
            // Arrange
            PersonDataModel person = PersonDataModelTestData.GetPersonDataModel();
            PersonDataModelToEmployeeDomainModelMapper dataMapper = new();

            // Act
            Result<Employee> employee = dataMapper.Map(person);

            // Assert
            Assert.Equal(2, employee.Value.DepartmentHistories.Count);
        }

        [Fact]
        public void PersonDataModelToEmployeeDomainModelMapper_Map_ShouldReturn_EmployeeAggregateRoot_WithThree_PayHistories()
        {
            // Arrange
            PersonDataModel person = PersonDataModelTestData.GetPersonDataModel();
            PersonDataModelToEmployeeDomainModelMapper dataMapper = new();

            // Act
            Result<Employee> employee = dataMapper.Map(person);

            // Assert
            Assert.Equal(3, employee.Value.PayHistories.Count);
        }

        [Fact]
        public void PersonDataModelToEmployeeDomainModelMapper_Map_ShouldReturn_EmployeeAggregateRoot_WithOne_Address()
        {
            // Arrange
            PersonDataModel person = PersonDataModelTestData.GetPersonDataModel();
            PersonDataModelToEmployeeDomainModelMapper dataMapper = new();

            // Act
            Result<Employee> employee = dataMapper.Map(person);

            // Assert
            Assert.Single(employee.Value.Addresses);
        }

        [Fact]
        public void PersonDataModelToEmployeeDomainModelMapper_Map_ShouldReturn_EmployeeAggregateRoot_WithOne_EmailAddress()
        {
            // Arrange
            PersonDataModel person = PersonDataModelTestData.GetPersonDataModel();
            PersonDataModelToEmployeeDomainModelMapper dataMapper = new();

            // Act
            Result<Employee> employee = dataMapper.Map(person);

            // Assert
            Assert.Single(employee.Value.EmailAddresses);
        }
    }
}