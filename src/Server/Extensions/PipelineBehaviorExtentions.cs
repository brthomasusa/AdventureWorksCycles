using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Features.HumanResources.DeleteEmployee;
using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Application.Interfaces.Messaging;

namespace AWC.Server.Extensions
{
    public static class PipelineBehaviorExtentions
    {
        public static IServiceCollection AddPipelineBehaviorServices(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(CommandValidator<CreateEmployeeCommand>), typeof(CreateEmployeeBusinessRuleValidator))
                .AddScoped(typeof(CommandValidator<DeleteEmployeeCommand>), typeof(DeleteEmployeeBusinessRuleValidator))
                .AddScoped(typeof(CommandValidator<UpdateEmployeeCommand>), typeof(UpdateEmployeeBusinessRuleValidator))
                .AddScoped(typeof(CommandValidator<UpdateCompanyCommand>), typeof(UpdateCompanyBusinessRuleValidator));
        }
    }
}
