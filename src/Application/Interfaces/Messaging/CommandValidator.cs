using AWC.SharedKernel.Utilities;

namespace AWC.Application.Interfaces.Messaging
{
    public abstract class CommandValidator<TCommand> : ICommandValidator<TCommand>
    {
        protected ICommandValidator<TCommand>? Next { get; private set; }

        public void SetNext(ICommandValidator<TCommand> next)
        {
            Next = next;
        }

        public virtual async Task<Result> Validate(TCommand command)
        {
            if (Next is not null)
            {
                await Next.Validate(command);
            }

            return Result.Success();
        }
    }
}