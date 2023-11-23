using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTest.Base
{
    public static class CompanyTestData
    {
        public static Company GetCompanyForUpdateWithValidData()
        {
            Result<Company> result = Company.Create
            (
                new CompanyID(1),
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

            return result.Value;
        }

        public static Company GetCompanyForUpdateWithInvalidCompanyID()
        {
            Result<Company> result = Company.Create
            (
                new CompanyID(11),
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

            return result.Value;
        }

        public static Company GetCompanyWithDeptAndShift()
        {
            Result<Company> result = Company.Create
            (
                new CompanyID(0),
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

            _ = result.Value.AddDepartment
            (
                new DepartmentID(1),
                "QA",
                "Quality Assurance"
            );

            _ = result.Value.AddDepartment
            (
                new DepartmentID(2),
                "R&D",
                "Research and Development"
            );

            _ = result.Value.AddShift
            (
                new ShiftID(1),
                "Midnight",
                23,
                0,
                7,
                0
            );

            _ = result.Value.AddShift
            (
                new ShiftID(2),
                "Weekend",
                10,
                0,
                18,
                0
            );

            return result.Value;
        }

        public static UpdateCompanyCommand GetUpdateCompanyCommandWithValidData()
            => new()
            {
                CompanyID = 1,
                CompanyName = "Test Company",
                LegalName = "Test Company",
                EIN = "123456789",
                CompanyWebSite = "https://www.testcompany.com",
                MailAddressLine1 = "PO Box 6429",
                MailAddressLine2 = null,
                MailCity = "Austin",
                MailStateProvinceID = 73,
                MailPostalCode = "78123",
                DeliveryAddressLine1 = "123 Main Street",
                DeliveryAddressLine2 = "Suite 1",
                DeliveryCity = "Austin",
                DeliveryStateProvinceID = 73,
                DeliveryPostalCode = "78123",
                Telephone = "512-555-5555",
                Fax = "512-555-9999"
            };



        public static UpdateCompanyCommand GetUpdateCompanyCommandWithInvalidData()
            => new()
            {
                CompanyID = 1,
                CompanyName = "Test Company",
                LegalName = "Test Company",
                EIN = "123",
                CompanyWebSite = "https://www.testcompany.com",
                MailAddressLine1 = "PO Box 6429",
                MailAddressLine2 = null,
                MailCity = "Austin",
                MailStateProvinceID = 73,
                MailPostalCode = "78123",
                DeliveryAddressLine1 = "123 Main Street",
                DeliveryAddressLine2 = "Suite 1",
                DeliveryCity = "Austin",
                DeliveryStateProvinceID = 73,
                DeliveryPostalCode = "78123",
                Telephone = "512-555-5555",
                Fax = "512-555-9999"
            };


    }
}