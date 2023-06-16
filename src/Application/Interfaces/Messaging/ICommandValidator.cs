using AWC.SharedKernel.Utilities;
using MediatR;

namespace AWC.Application.Interfaces.Messaging
{
    public interface ICommandValidator<TCommand> : IRequest<TCommand>
    {
        Task<Result> Validate(TCommand command);

        void SetNext(ICommandValidator<TCommand> next);
    }
}