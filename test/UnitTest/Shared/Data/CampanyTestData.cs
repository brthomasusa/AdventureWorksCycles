using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using CompanyDataModel = AWC.Infrastructure.Persistence.DataModels.HumanResources.Company;
using CompanyDomainModel = AWC.Core.Entities.HumanResources.Company;

namespace AWC.UnitTest.Shared.Data
{
    public static class CampanyTestData
    {
        public static Result<CompanyDomainModel> CompanyResultWithValidData()
            => CompanyDomainModel.Create
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

        public static Result<CompanyDomainModel> CompanyResult_Invalid_CompanyName()
            => CompanyDomainModel.Create
            (
                new CompanyID(1),
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

        public static CompanyDataModel GetCompanyDataModel()
            => new()
            {
                CompanyID = 1,
                CompanyName = "Google",
                LegalName = "Google LLC",
                EIN = "987654321",
                WebsiteUrl = "https://www.testcompany.com",
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

        public static List<AWC.Infrastructure.Persistence.DataModels.HumanResources.Department> GetDepartmentDataModels()
            => new List<AWC.Infrastructure.Persistence.DataModels.HumanResources.Department>()
            {
                new () {DepartmentID = 1, Name = "Engineering", GroupName = "R & D"},
                new () {DepartmentID = 2, Name = "HR", GroupName = "Human Resources"},
                new() { DepartmentID = 3, Name = "Sales", GroupName = "Marketing" },
                new() { DepartmentID = 4, Name = "Facilities", GroupName = "Maintenance" },
                new() { DepartmentID = 5, Name = "Production Q&A", GroupName = "Quality & Assurance" }
            };

        public static List<AWC.Infrastructure.Persistence.DataModels.HumanResources.Shift> GetShiftDataModels()
            => new List<AWC.Infrastructure.Persistence.DataModels.HumanResources.Shift>()
            {
                new () {ShiftID = 1, Name = "Morning Shift", StartTime = new TimeSpan(8,0,0), EndTime = new TimeSpan(16,0,0)},
                new () {ShiftID = 2, Name = "Afternoon Shift", StartTime = new TimeSpan(16,0,0), EndTime = new TimeSpan(23,59,59)},
                new () {ShiftID = 3, Name = "Midnight Shift", StartTime = new TimeSpan(0,0,1), EndTime = new TimeSpan(8,0,0)}
            };
    }
}