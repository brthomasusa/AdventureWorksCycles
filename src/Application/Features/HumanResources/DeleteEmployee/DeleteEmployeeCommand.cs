using AWC.Application.Interfaces.Messaging;
using MediatR;

namespace AWC.Application.Features.HumanResources.DeleteEmployee
{
    public sealed record DeleteEmployeeCommand(int EmployeeID) : ICommand<int>;
}