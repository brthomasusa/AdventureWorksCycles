using AWC.Shared.Commands.HumanResources;
using Fluxor;

namespace AWC.Client.Features.HumanResources.UpdateCompanyDetails.Store
{
    public sealed class UpdateCompanyDetailsFeature : Feature<UpdateCompanyDetailsState>
    {
        public override string GetName() => "UpdateCompanyDetails";

        protected override UpdateCompanyDetailsState GetInitialState() =>
            new()
            {
                Initialized = false,
                Loading = false,
                Submitting = false,
                Submitted = false,
                ErrorMessage = string.Empty,
                CommandModel = new CompanyGenericCommand(),
                CompanyID = 1,
                StateCodes = new()
            };
    }
}