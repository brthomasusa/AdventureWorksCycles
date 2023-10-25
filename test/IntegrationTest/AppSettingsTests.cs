using Microsoft.Extensions.Configuration;
using TestSupport.Helpers;
using Xunit.Extensions.AssertExtensions;

namespace AWC.IntegrationTest
{
    public class AppSettingsTests
    {
        [Fact]
        public void ShouldGetConnStringFromAppSettings()
        {
            //SETUP

            //ATTEMPT
            var config = AppSettings.GetConfiguration();

            //VERIFY
            config.GetConnectionString("DefaultConnection")
                .ShouldEqual("Server=tcp:mssql-server,1433;Database=AdventureWorks_Test;User Id=sa;Password=Info99Gum;TrustServerCertificate=True");
        }

        [Fact]
        public void Should_Get_ConnectionString_From_Env_Variable()
        {
            string? connstr = Environment.GetEnvironmentVariable("ConnectionStrings__TestConnection");

            Assert.NotNull(connstr);
            Assert.Equal("Server=tcp:mssql-server,1433;Database=AdventureWorks_Test;User Id=sa;Password=Info99Gum;TrustServerCertificate=True", connstr);
        }

        [Fact]
        public void Should_Get_DevelopmentEnvironment_From_Env_Variable()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            Assert.NotNull(env);
            Assert.Equal("Development", env);
        }
    }
}