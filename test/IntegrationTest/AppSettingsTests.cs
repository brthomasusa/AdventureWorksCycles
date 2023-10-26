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
                .ShouldEqual("Server=tcp:mssql-server,1433;Database=AdventureWorks_Test;User Id=sa;;TrustServerCertificate=True");
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