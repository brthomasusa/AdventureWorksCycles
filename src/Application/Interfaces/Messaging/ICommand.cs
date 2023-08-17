using AWC.SharedKernel.Utilities;
using MediatR;

namespace AWC.Application.Interfaces.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}