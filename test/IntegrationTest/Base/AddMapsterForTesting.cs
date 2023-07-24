using System.Reflection;
using AWC.Infrastructure;
using Mapster;
using MapsterMapper;

namespace AWC.IntegrationTest.Base
{
    public static class AddMapsterForTesting
    {
        public static Mapper GetMapper()
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly(), InfrastructureAssembly.Instance);
            return new Mapper(config);
        }
    }
}