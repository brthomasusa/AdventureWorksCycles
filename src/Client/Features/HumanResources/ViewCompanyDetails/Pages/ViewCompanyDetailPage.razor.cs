using AWC.Client.Features.HumanResources.ViewCompanyDetails.Store;
using AWC.Shared.Queries.HumanResources;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace AWC.Client.Features.HumanResources.ViewCompanyDetails.Pages
{
    public partial class ViewCompanyDetailPage
    {
        [Inject] private IState<ViewCompanyDetailState>? ViewCompanyDetailState { get; set; }
        [Inject] private IDispatcher? Dispatcher { get; set; }
        [Inject] private NavigationManager? NavManager { get; set; }
        private CompanyDetails? DetailsModel => ViewCompanyDetailState!.Value.DetailsModel;
        private bool Loading => ViewCompanyDetailState!.Value.Loading;

        protected override void OnInitialized()
        {
            if (!ViewCompanyDetailState!.Value.Initialized)
            {
                Dispatcher!.Dispatch(new SetViewCompanyDetailsAction(ViewCompanyDetailState!.Value.CompanyID));
            }

            base.OnInitialized();
        }

        private void EditButtonClicked()
        {
            NavManager!.NavigateTo("/Features/HumanResources/UpdateCompanyDetails/Pages/UpdateCompanyDetailsPage");
        }
    }
}