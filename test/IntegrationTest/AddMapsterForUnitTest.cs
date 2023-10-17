using Mapster;
using MapsterMapper;
using System.Reflection;
using AWC.Application;
using AWC.Infrastructure;
using AWC.Server;

namespace AWC.IntegrationTest
{
    public static class AddMapsterForUnitTests
    {
        public static Mapper GetMapper()
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(
                typeof(InfrastructureAssembly).Assembly,
                typeof(ApplicationAssembly).Assembly,
                typeof(ServerAssembly).Assembly
            );
            config.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

            return new Mapper(config);
        }
    }
}