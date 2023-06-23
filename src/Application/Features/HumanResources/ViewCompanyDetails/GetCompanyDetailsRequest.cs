using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.HumanResources;

namespace AWC.Application.Features.HumanResources.ViewCompanyDetails
{
    public sealed record GetCompanyDetailsRequest(int CompanyID) : IQuery<CompanyDetailsForDisplay>;
}