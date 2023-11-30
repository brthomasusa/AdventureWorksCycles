using AWC.Core.Entities.HumanResources;
using AWC.Core.Interfaces.HumanResouces;
using AWC.UnitTest.Shared.Data.MockRepositories;
using Moq;

namespace AWC.UnitTest.Shared.MockRepositories
{
    internal class MockCompanyWriteRepository
    {
        public static Mock<ICompanyWriteRepository> GetMock()
        {
            Result<Company> company = GetCompanyMockData.GetCompanyWithDepartmentsAndShifts();

            var mock = new Mock<ICompanyWriteRepository>();

            mock.Setup(m => m.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>())).ReturnsAsync(company);

            mock.Setup(m => m.Update(It.IsAny<Company>()))
               .ReturnsAsync(() => { return Result<int>.Success<int>(1); });
            return mock;
        }
    }
}