using AWC.SharedKernel.Utilities;
using MediatR;

namespace AWC.Application.Interfaces.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}