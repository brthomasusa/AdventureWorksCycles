using AWC.Infrastructure.Persistence.DataModels.HumanResources;

namespace AWC.UnitTest.Shared.Data.MockRepositories
{
    public class GetCompanyMockData
    {
        public static List<Company> GetCompanies()
            => new()
            {
                new()
                {
                    CompanyID = 1,
                    CompanyName = "Test Company",
                    LegalName = "Test Company LLC",
                    EIN = "123456789",
                    WebsiteUrl = "https://www.testcompany.com",
                    MailAddressLine1 = "PO Box 25",
                    MailAddressLine2 = null,
                    MailCity = "Austin",
                    MailStateProvinceID = 73,
                    MailPostalCode = "78880",
                    DeliveryAddressLine1 = "123 Main Street",
                    DeliveryAddressLine2 = "Suite 1",
                    DeliveryCity = "Austin",
                    DeliveryStateProvinceID = 73,
                    DeliveryPostalCode = "78880",
                    Telephone = "512-555-5678",
                    Fax = "512-555-1234"
                },
                new()
                {
                    CompanyID = 2,
                    CompanyName = "Another Company",
                    LegalName = "Another Company LLC",
                    EIN = "987654321",
                    WebsiteUrl = "https://www.anothercompany.com",
                    MailAddressLine1 = "PO Box 25",
                    MailAddressLine2 = null,
                    MailCity = "Austin",
                    MailStateProvinceID = 73,
                    MailPostalCode = "78880",
                    DeliveryAddressLine1 = "123 Main Street",
                    DeliveryAddressLine2 = "Suite 1",
                    DeliveryCity = "Austin",
                    DeliveryStateProvinceID = 73,
                    DeliveryPostalCode = "78880",
                    Telephone = "512-555-5678",
                    Fax = "512-555-1234"
                }
            };
    }
}