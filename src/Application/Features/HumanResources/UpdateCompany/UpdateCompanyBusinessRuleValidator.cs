using AWC.Application.Interfaces.Messaging;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.UpdateCompany
{
    public sealed class UpdateCompanyBusinessRuleValidator : CommandValidator<UpdateCompanyCommand>
    {
        public override async Task<Result> Validate(UpdateCompanyCommand command)
        {
            return await Task.FromResult(Result.Success());
        }
    }
}