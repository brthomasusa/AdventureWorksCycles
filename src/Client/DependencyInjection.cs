using System.Reflection;
using Mapster;
using MapsterMapper;
using FluentValidation;
using Fluxor;

namespace AWC.Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            config.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }

        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(App).Assembly);

            return services;
        }

        public static IServiceCollection AddFluxor(this IServiceCollection services)
        {
            var currentAssembly = typeof(Program).Assembly;
            services.AddFluxor(options =>
            {
                options.ScanAssemblies(currentAssembly);
#if DEBUG
                options.UseReduxDevTools();
#endif
            });

            return services;
        }
    }
}