using AWC.Application;
using AWC.Application.Behaviors;
using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Server.Contracts;
using AWC.Server.Extensions;
using AWC.Server.Interceptors;
using AWC.Server.Middleware;
using Carter;
using FluentValidation;
using MediatR;
using NLog;
using NLog.Web;

namespace AWC.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddCarter();
            services.AddMediatR(ApplicationAssembly.Instance);
            services.AddValidatorsFromAssemblyContaining<CreateEmployeeDataValidator>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(BusinessRulesValidationBehavior<,>));
            services.AddPipelineBehaviorServices();

            // Add services from namespace Server.Extensions to the container.
            services.ConfigureCors();
            services.AddInfrastructureServices();
            services.ConfigureEfCoreDbContext();
            services.ConfigureDapper();
            services.AddMappings();
            services.AddRepositoryServices();
            services.AddTransient<ExceptionHandlingMiddleware>();

            services.AddGrpc(options =>
            {
                options.EnableDetailedErrors = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
                options.Interceptors.Add<ServerTracingInterceptor>();
            });

            services.AddGrpcReflection();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
            app.MapGrpcReflectionService();
            app.MapGrpcService<CompanyContractService>().RequireCors("AllowAll");
            app.MapGrpcService<LookupsContractService>().RequireCors("AllowAll");
            app.MapGrpcService<EmployeeContractService>().RequireCors("AllowAll");


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");
            app.MapCarter();

            app.Run();
        }
    }
}