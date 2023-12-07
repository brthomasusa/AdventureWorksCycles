using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Mappings.HumanResources;
using AWC.Core.Entities.HumanResources;
using AWC.UnitTest.Shared;
using AWC.UnitTest.Shared.Data;
using MapsterMapper;

namespace AWC.UnitTest.Application.Mappings.HumanResources
{
    public class CreateEmployeeCommandToEmployeeDomainModelMapperTest
    {
        private readonly IMapper _mapper;

        public CreateEmployeeCommandToEmployeeDomainModelMapperTest()
            => _mapper = AddMapsterForUnitTests.GetMapper();

        [Fact]
        public void CreateEmployeeCommandToEmployeeDomainModelMapper_Map_ShouldReturn_Success()
        {
            // Arrange
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            CreateEmployeeCommandToEmployeeDomainModelMapper modelMapper = new(_mapper);

            // Act
            Result<Employee> result = modelMapper.Map(command);

            // Assert
            Assert.Single(result.Value.PayHistories);
            Assert.Single(result.Value.DepartmentHistories);
            Assert.Single(result.Value.Addresses);
            Assert.Single(result.Value.EmailAddresses);
            Assert.Single(result.Value.Telephones);
        }
    }
}