using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Core.Entities.HumanResources;
using AWC.UnitTest.Shared;
using AWC.UnitTest.Shared.Data;
using MapsterMapper;

namespace AWC.UnitTest.Application.Mappings.HumanResources
{
    public class EmployeeMappingConfigTest
    {
        private readonly IMapper _mapper;

        public EmployeeMappingConfigTest()
            => _mapper = AddMapsterForUnitTests.GetMapper();

        [Fact]
        public void UpdateEmployeeCommandMappingConfig_Map_ShouldReturn_ResultWith_CompanyDomainModel()
        {
            // Map to an Employee domain model from an UpdateEmployeeCommand

            // Arrange
            UpdateEmployeeCommand command = EmployeeTestData.GetUpdateEmployeeCommand_ValidData();

            // Act
            Result<Employee> result = _mapper.Map<Result<Employee>>(command);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(command.BusinessEntityID, result.Value.Id.Value);
            Assert.Equal(command.LastName, result.Value.Name.LastName);
        }

        [Fact]
        public void CreateEmployeeCommandMappingConfig_Map_ShouldReturn_ResultWith_CompanyDomainModel()
        {
            // Map to an Employee domain model from a CreateEmployeeCommand

            // Arrange
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();

            // Act
            Result<Employee> result = _mapper.Map<Result<Employee>>(command);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(command.BusinessEntityID, result.Value.Id.Value);
            Assert.Equal(command.LastName, result.Value.Name.LastName);
        }
    }
}