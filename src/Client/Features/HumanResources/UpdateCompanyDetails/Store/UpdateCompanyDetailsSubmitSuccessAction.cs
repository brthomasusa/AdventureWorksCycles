using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;

namespace AWC.Client.Features.HumanResources.UpdateCompanyDetails.Store
{
    public sealed record UpdateCompanyDetailsSubmitSuccessAction(int SuppressSonarqubeWarning = 0);
}