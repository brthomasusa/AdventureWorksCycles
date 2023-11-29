using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Core.Interfaces.HumanResouces;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories.HumanResources;
using Microsoft.Extensions.Logging;
using MapsterMapper;
using Moq;

namespace AWC.UnitTest.Shared.MockRepositories
{
    internal class MockWriteRepositoryManager
    {
        public static Mock<IWriteRepositoryManager> GetMock()
        {
            var mock = new Mock<IWriteRepositoryManager>();


            return mock;
        }
    }
}