using CompanyDomainModel = AWC.Core.Entities.HumanResources.Company;
using AWC.Infrastructure.Persistence.Mappings.HumanResources;
using AWC.UnitTest.Shared.Data;

namespace AWC.UnitTest.Infrastructure.Persistence.HumanResources.Mappings
{
    public class CompanyDomainModelDataMapperTest
    {
        [Fact]
        public void CompanyDomainModelDataMapper_MapFromDataModel_ShouldReturn_1Company_5Depts_3Shift()
        {
            // Arrange
            var company = CampanyTestData.GetCompanyDataModel();
            var departments = CampanyTestData.GetDepartmentDataModels();
            var shifts = CampanyTestData.GetShiftDataModels();

            // Act
            Result<CompanyDomainModel> result = CompanyDomainModelDataMapper.MapFromDataModel(company, departments, shifts);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(5, result.Value.Departments.Count);
            Assert.Equal(3, result.Value.Shifts.Count);
        }

        [Fact]
        public void CompanyDomainModelDataMapper_MapFromDataModel_ShouldReturn_1Company_0Depts_3Shift()
        {
            // Arrange
            var company = CampanyTestData.GetCompanyDataModel();
            var departments = new List<AWC.Infrastructure.Persistence.DataModels.HumanResources.Department>();
            var shifts = CampanyTestData.GetShiftDataModels();

            // Act
            Result<CompanyDomainModel> result = CompanyDomainModelDataMapper.MapFromDataModel(company, departments, shifts);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Empty(result.Value.Departments.ToList());
            Assert.Equal(3, result.Value.Shifts.Count);
        }

        [Fact]
        public void CompanyDomainModelDataMapper_MapFromDataModel_ShouldReturn_1Company_5Depts_0Shift()
        {
            // Arrange
            var company = CampanyTestData.GetCompanyDataModel();
            var departments = CampanyTestData.GetDepartmentDataModels();
            var shifts = new List<AWC.Infrastructure.Persistence.DataModels.HumanResources.Shift>();

            // Act
            Result<CompanyDomainModel> result = CompanyDomainModelDataMapper.MapFromDataModel(company, departments, shifts);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(5, result.Value.Departments.Count);
            Assert.Empty(result.Value.Shifts.ToList());
        }
    }
}