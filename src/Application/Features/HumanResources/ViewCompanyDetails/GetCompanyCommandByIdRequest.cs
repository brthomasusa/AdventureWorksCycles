using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Queries.HumanResources;

namespace AWC.Application.Features.HumanResources.ViewCompanyDetails
{
    public sealed record GetCompanyCommandByIdRequest(int CompanyID) : IQuery<GetCompanyCommandByIdResponse>;
}