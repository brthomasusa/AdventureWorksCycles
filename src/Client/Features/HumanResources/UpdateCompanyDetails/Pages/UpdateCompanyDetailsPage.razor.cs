#pragma warning disable CS8795

using System.Text.RegularExpressions;
using AWC.Client.Features.HumanResources.UpdateCompanyDetails.Store;
using AWC.Shared.Commands.HumanResources;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;

namespace AWC.Client.Features.HumanResources.UpdateCompanyDetails.Pages
{
    public partial class UpdateCompanyDetailsPage
    {
        [Inject] private IState<UpdateCompanyDetailsState>? UpdateCompanyDetailsState { get; set; }
        [Inject] private IDispatcher? Dispatcher { get; set; }
        [Inject] private NavigationManager? NavManager { get; set; }
        [Inject] protected DialogService? DialogService { get; set; }

        [Inject] protected TooltipService? TooltipService { get; set; }

        [Inject] protected ContextMenuService? ContextMenuService { get; set; }

        [Inject] protected NotificationService? NotificationService { get; set; }
        private const string ReturnUri = "/Features/HumanResources/ViewCompanyDetail/Pages/ViewCompanyDetailPage";
        private CompanyGenericCommand? CommandModel => UpdateCompanyDetailsState!.Value.CommandModel;
        private bool Loading => UpdateCompanyDetailsState!.Value.Loading;
        private readonly Variant variant = Variant.Filled;

        protected override void OnInitialized()
        {
            if (!UpdateCompanyDetailsState!.Value.StateCodes!.Any())
            {
                Dispatcher!.Dispatch(new LoadStateCodesAction());
            }

            if (!UpdateCompanyDetailsState!.Value.Initialized)
            {
                Dispatcher!.Dispatch(new LoadCompanyDetailsForEditingAction(UpdateCompanyDetailsState!.Value.CompanyID));
            }

            base.OnInitialized();
        }

        private void OnValidSubmit()
        {
            Dispatcher!.Dispatch(new UpdateCompanyDetailsSubmitAction(UpdateCompanyDetailsState!.Value.CommandModel!));
            NavManager!.NavigateTo("/Features/HumanResources/ViewCompanyDetail/Pages/ViewCompanyDetailPage");
        }

        private void OnInvalidSubmit()
        {
            NotificationService!.Notify(
                new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Style = "position: relative; left: -500px; top: 490px; width: 100%",
                    Detail = "Update of company info was not successful.",
                    Duration = 2500
                }
            );
        }

        private void OnCancelEdit(MouseEventArgs _)
        {
            Dispatcher!.Dispatch(new SetUpdateInitializeFlagAction(false));
            NavManager!.NavigateTo("/Features/HumanResources/ViewCompanyDetail/Pages/ViewCompanyDetailPage");
        }

        private bool ValidateEIN(string ein)
        {
            return EinRegex().IsMatch(ein);
        }

        [GeneratedRegex("^\\d{9}|\\d{2}-\\d{7}$")]
        private static partial Regex EinRegex();
    }
}