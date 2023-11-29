using AWC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AWC.IntegrationTest.Base
{
    public abstract class TestBase : IDisposable
    {
        protected readonly AwcContext _dbContext;
        protected readonly DapperContext _dapperCtx;

        protected TestBase()
        {
            string? connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__TestConnection");
            _dapperCtx = new DapperContext(connectionString!);

            var optionsBuilder = new DbContextOptionsBuilder<AwcContext>();

            optionsBuilder.UseSqlServer(
                connectionString!,
                msSqlOptions => msSqlOptions.MigrationsAssembly(typeof(AwcContext).Assembly.FullName)
            )
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();

            _dbContext = new AwcContext(optionsBuilder.Options);
            _dbContext.Database.ExecuteSqlRaw("EXEC dbo.usp_InitializeTestDb");
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}