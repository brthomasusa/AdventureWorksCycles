#pragma warning disable CS8604

using Microsoft.EntityFrameworkCore;
using AWC.Application;
using AWC.Infrastructure;
using AWC.Infrastructure.Persistence;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Repositories;
using AWC.SharedKernel.Guards;
using AWC.SharedKernel.Interfaces;
using Mapster;
using MapsterMapper;

namespace AWC.Server.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding", "validation-errors-text"));
            });

        public static void ConfigureEfCoreDbContext(this IServiceCollection services)
        {
            string? connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__TestConnection");
            Guard.Against.NullOrEmpty(connectionString);

            services.AddDbContext<AwcContext>(options =>
                options.UseSqlServer(
                    connectionString,
                    msSqlOptions => msSqlOptions.MigrationsAssembly(typeof(AwcContext).Assembly.FullName)
                )
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            );
        }

        public static void ConfigureDapper(this IServiceCollection services)
        {
            string? connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__TestConnection");
            Guard.Against.NullOrEmpty(connectionString);
            _ = services.AddSingleton<DapperContext>(_ => new DapperContext(connectionString));
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IWriteRepositoryManager, WriteRepositoryManager>()
                .AddScoped<IReadRepositoryManager, ReadRepositoryManager>()
                .AddScoped<IValidationRepositoryManager, ValidationRepositoryManager>()
                .AddScoped<ILookupsRepositoryManager, LookupsRepositoryManager>();
        }

        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(
                ServerAssembly.Instance,
                InfrastructureAssembly.Instance,
                ApplicationAssembly.Instance
            );
            config.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}