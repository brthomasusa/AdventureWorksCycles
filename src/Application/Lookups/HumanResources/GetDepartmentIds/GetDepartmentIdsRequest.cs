using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.Lookups.HumanResources;

namespace AWC.Application.Lookups.HumanResources.GetDepartmentIds
{
    public sealed record GetDepartmentIdsRequest(int SuppressSonarqubeWarning = 0) : IQuery<List<DepartmentId>>;
}