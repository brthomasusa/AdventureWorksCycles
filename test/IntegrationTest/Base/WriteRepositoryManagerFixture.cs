using AWC.Infrastructure.Persistence.Repositories;
using MapsterMapper;

namespace AWC.IntegrationTest.Base
{
    public sealed class WriteRepositoryManagerFixture : TestBase
    {
        public WriteRepositoryManager WriteRepository { get; private set; }

        public WriteRepositoryManagerFixture()
        {
            IMapper _mapper = AWC.IntegrationTest.AddMapsterForUnitTests.GetMapper();
            using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
            var logger = loggerFactory.CreateLogger<WriteRepositoryManager>();

            WriteRepository = new(_dbContext, logger, _mapper);
        }
    }
}