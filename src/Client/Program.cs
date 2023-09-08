using AWC.Client;
using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Services.HumanResources;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMappings();
builder.Services.AddFluentValidation();
builder.Services.AddFluxor();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<IEmployeeRepositoryService, EmployeeRepositoryService>();
builder.Services.AddScoped<ICompanyRepositoryService, CompanyRepositoryService>();

builder.Services.AddSingleton(services =>
{
    var navigationManager = services.GetRequiredService<NavigationManager>();
    var backendUrl = navigationManager.BaseUri;

    var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler());

    return GrpcChannel.ForAddress(backendUrl, new GrpcChannelOptions { HttpHandler = httpHandler });
});

await builder.Build().RunAsync();

namespace AWC.Client
{
    public partial class Program
    {

    }
}