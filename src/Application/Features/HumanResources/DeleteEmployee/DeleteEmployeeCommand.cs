using AWC.Application.Interfaces.Messaging;

namespace AWC.Application.Features.HumanResources.DeleteEmployee
{
    public sealed record DeleteEmployeeCommand(int BusinessEntityID) : ICommand<int>;
}