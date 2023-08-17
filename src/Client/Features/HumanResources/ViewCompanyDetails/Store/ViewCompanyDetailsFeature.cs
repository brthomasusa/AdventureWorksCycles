using Fluxor;

namespace AWC.Client.Features.HumanResources.ViewCompanyDetails.Store
{
    public sealed class ViewCompanyDetailsFeature : Feature<ViewCompanyDetailState>
    {
        public override string GetName() => "ViewCompanyDetail";

        protected override ViewCompanyDetailState GetInitialState() =>
            new()
            {
                Initialized = false,
                Loading = false,
                ErrorMessage = string.Empty,
                DetailsModel = null,
                CompanyID = 1
            };
    }
}