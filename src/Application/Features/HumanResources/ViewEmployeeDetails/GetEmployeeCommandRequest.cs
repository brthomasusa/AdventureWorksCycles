using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.HumanResources;

namespace AWC.Application.Features.HumanResources.ViewEmployeeDetails
{
    public sealed record GetEmployeeCommandRequest(int EmployeeID) : IQuery<EmployeeGenericCommand>;
}