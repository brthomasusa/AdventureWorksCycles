using AWC.SharedKernel.Utilities;
using MediatR;

namespace AWC.Shared.Interfaces
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}