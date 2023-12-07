using AWC.Core.Entities.HumanResources;
using AWC.Core.Interfaces.HumanResouces;
using AWC.UnitTest.Shared.Data;
using Moq;

namespace AWC.UnitTest.Shared.MockRepositories
{
    internal class MockEmployeeWriteRepository
    {
        public static Mock<IEmployeeWriteRepository> GetMock()
        {
            Result<Employee> result = EmployeeTestData.GetValidEmployee();

            var mock = new Mock<IEmployeeWriteRepository>();

            mock.Setup(m => m.GetByIdAsync(1, It.IsAny<bool>())).ReturnsAsync(result);

            mock.Setup(m => m.InsertAsync(It.IsAny<Employee>()))
               .ReturnsAsync(() => { return Result<int>.Success<int>(1); });

            mock.Setup(m => m.Update(It.IsAny<Employee>()))
               .ReturnsAsync(() => { return Result<int>.Success<int>(1); });

            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .ReturnsAsync(() => { return Result<int>.Success<int>(1); });

            return mock;
        }
    }
}
