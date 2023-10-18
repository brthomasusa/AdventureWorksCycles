using AWC.Core.HumanResources;
using AWC.UnitTest.Data;

namespace AWC.UnitTest.HumanResources
{
    public class CompanyAggregate_Tests
    {
        [Fact]
        public void Company_Create_ValidData_ShouldSucceed()
        {
            Result<Company> result = CampanyTestData.CompanyResultWithValidData();

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Company_Create_Invalid_MissingCompanyName_ShouldFail()
        {
            Result<Company> result = CampanyTestData.CompanyResult_Invalid_CompanyName();

            Assert.True(result.IsFailure);
        }
    }
}