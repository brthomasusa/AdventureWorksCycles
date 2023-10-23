#pragma warning disable CS8601, CS8604

using AWC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestSupport.Helpers;

namespace AWC.IntegrationTest.Base
{
    public abstract class TestBase : IDisposable
    {
        protected readonly string _connectionString;
        protected readonly AwcContext _dbContext;
        protected readonly DapperContext _dapperCtx;

        protected TestBase()
        {
            var config = AppSettings.GetConfiguration();
            _connectionString = config.GetConnectionString("DefaultConnection");
            _dapperCtx = new DapperContext(_connectionString);

            var optionsBuilder = new DbContextOptionsBuilder<AwcContext>();

            optionsBuilder.UseSqlServer(
                _connectionString,
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