using Microsoft.Extensions.Logging;
using AWC.Core.Interfaces.HumanResouces;
using AWC.Infrastructure.Persistence;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Infrastructure.Persistence.Repositories.HumanResources;
using MapsterMapper;

namespace AWC.UnitTest.Shared.MockDbContext
{
    public class CompanyRepositoryMock
    {
        public static ICompanyWriteRepository GetMock()
        {
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<WriteRepositoryManager>();
            IMapper mapper = AddMapsterForUnitTests.GetMapper(); ;

            List<Company> companies = GetCompanyMockData.GetCompanies();
            AwcContext dbContextMock = DbContextMock.GetMock<Company, AwcContext>(companies, x => x.Company!);

            return new CompanyWriteRepository(dbContextMock, logger, mapper);
        }
    }
}