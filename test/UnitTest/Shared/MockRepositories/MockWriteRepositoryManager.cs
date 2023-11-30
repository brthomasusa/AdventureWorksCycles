using AWC.Infrastructure.Persistence.Interfaces;
using Moq;

namespace AWC.UnitTest.Shared.MockRepositories
{
    internal class MockWriteRepositoryManager
    {
        public static Mock<IWriteRepositoryManager> GetMock()
        {
            var mock = new Mock<IWriteRepositoryManager>();

            var companyRepoMock = MockCompanyWriteRepository.GetMock();
            var employeeRepoMock = MockEmployeeWriteRepository.GetMock();

            mock.Setup(m => m.CompanyAggregateRepository).Returns(() => companyRepoMock.Object);
            mock.Setup(m => m.EmployeeAggregateRepository).Returns(() => employeeRepoMock.Object);

            return mock;
        }
    }
}