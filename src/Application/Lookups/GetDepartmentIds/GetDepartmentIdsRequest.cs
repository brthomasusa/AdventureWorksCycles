using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.Lookups;

namespace AWC.Application.Lookups.GetDepartmentIds
{
    public sealed record GetDepartmentIdsRequest() : IQuery<List<DepartmentId>>;
}