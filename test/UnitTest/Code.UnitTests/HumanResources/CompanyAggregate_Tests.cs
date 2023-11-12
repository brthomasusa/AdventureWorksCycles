using AWC.Core.Entities.HumanResources;
using AWC.UnitTest.Shared.Data;

namespace AWC.UnitTest.Code.UnitTests.HumanResources
{
    public class CompanyAggregate_Tests
    {
        [Fact]
        public void Company_Create_ValidData_ShouldSucceed()
        {
            Result<Company> result = CampanyTestData.CompanyResultWithValidData();

            Assert.True(result.IsSuccess);
        }

    }
}