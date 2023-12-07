using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Core.Entities.HumanResources;
using AWC.UnitTest.Shared;
using AWC.UnitTest.Shared.Data;
using MapsterMapper;

namespace AWC.UnitTest.Application.Mappings.HumanResources
{
    public class CompanyMappingConfigTest
    {
        private readonly IMapper _mapper;

        public CompanyMappingConfigTest()
            => _mapper = AddMapsterForUnitTests.GetMapper();

        [Fact]
        public void CompanyMappingConfig_Map_ShouldReturn_ResultWith_CompanyDomainModel()
        {
            // Arrange
            UpdateCompanyCommand command = CampanyTestData.GetUpdateCompanyCommandWithValidData();

            // Act
            Result<Company> result = _mapper.Map<Result<Company>>(command);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(command.CompanyID, result.Value.Id.Value);
            Assert.Equal(command.CompanyName, result.Value.CompanyName);
        }
    }
}