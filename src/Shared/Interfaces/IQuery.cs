using AWC.SharedKernel.Utilities;
using MediatR;

namespace AWC.Shared.Interfaces
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {

    }
}