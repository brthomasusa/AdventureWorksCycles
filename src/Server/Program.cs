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


var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
GlobalDiagnosticsContext.Set("logDirectory", Directory.GetCurrentDirectory());

logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Host.UseNLog();

    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();
    builder.Services.AddCarter();
    builder.Services.AddMediatR(ApplicationAssembly.Instance);
    builder.Services.AddValidatorsFromAssemblyContaining<CreateEmployeeDataValidator>();
    builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
    builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(BusinessRulesValidationBehavior<,>));
    builder.Services.AddPipelineBehaviorServices();

    // Add services from namespace Server.Extensions to the container.
    builder.Services.ConfigureCors();
    builder.Services.AddInfrastructureServices();
    builder.Services.ConfigureEfCoreDbContext(builder.Configuration);
    builder.Services.ConfigureDapper(builder.Configuration);
    builder.Services.AddMappings();
    builder.Services.AddRepositoryServices();
    builder.Services.AddTransient<ExceptionHandlingMiddleware>();

    builder.Services.AddGrpc(options =>
    {
        options.EnableDetailedErrors = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
        options.Interceptors.Add<ServerTracingInterceptor>();
    });

    builder.Services.AddGrpcReflection();

    var app = builder.Build();

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
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}

namespace AWC.Server
{
    public partial class Program
    {

    }
}
