// using AWC.Application.HumanResources.CreateEmployee;
// using AWC.Application.HumanResources.DeleteEmployee;
// using AWC.Application.HumanResources.UpdateEmployee;
using AWC.Application.Interfaces.Messaging;
// using AWC.Application.Organization.UpdateCompany;

namespace AWC.Server.Extensions
{
    public static class PipelineBehaviorExtentions
    {
        // public static IServiceCollection AddPipelineBehaviorServices(this IServiceCollection services)
        // {
        //     return services
        //         .AddScoped(typeof(CommandValidator<CreateEmployeeCommand>), typeof(CreateEmployeeBusinessRuleValidator))
        //         .AddScoped(typeof(CommandValidator<DeleteEmployeeCommand>), typeof(DeleteEmployeeBusinessRuleValidator))
        //         .AddScoped(typeof(CommandValidator<UpdateEmployeeCommand>), typeof(UpdateEmployeeBusinessRuleValidator))
        //         .AddScoped(typeof(CommandValidator<UpdateCompanyCommand>), typeof(UpdateCompanyBusinessRuleValidator));
        // }
    }
}