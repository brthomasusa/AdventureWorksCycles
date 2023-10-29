using AWC.Core.Entities.HumanResources;

namespace AWC.UnitTest.Shared.Data
{
    public static class CampanyTestData
    {
        public static Result<Company> CompanyResultWithValidData()
            => Company.Create
            (
                0,
                "Test Company",
                "Test Company",
                "123456789",
                "https://www.testcompany.com",
                "123 Main Street",
                "Suite 10",
                "Austin",
                73,
                "78123",
                "123 Main Street",
                "Suite 10",
                "Austin",
                73,
                "78123",
                "512-555-5555",
                "512-555-9999"
            );

        public static Result<Company> CompanyResult_Invalid_CompanyName()
            => Company.Create
            (
                0,
                "",
                "Test Company",
                "123456789",
                "https://www.testcompany.com",
                "123 Main Street",
                "Suite 10",
                "Austin",
                73,
                "78123",
                "123 Main Street",
                "Suite 10",
                "Austin",
                73,
                "78123",
                "512-555-5555",
                "512-555-9999"
            );
    }
}