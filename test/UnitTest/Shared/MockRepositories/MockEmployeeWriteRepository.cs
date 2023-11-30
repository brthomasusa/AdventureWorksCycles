using AWC.Core.Interfaces.HumanResouces;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.SharedKernel.Utilities;
using AWC.UnitTest.Shared.Data.MockRepositories;
using Moq;

namespace AWC.UnitTest.Shared.MockRepositories
{
    internal class MockEmployeeWriteRepository
    {
        public static Mock<IEmployeeWriteRepository> GetMock()
        {

            var mock = new Mock<IEmployeeWriteRepository>();

            return mock;
        }
    }
}