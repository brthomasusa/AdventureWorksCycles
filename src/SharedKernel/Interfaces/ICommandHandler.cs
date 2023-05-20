using AWC.SharedKernel.Utilities;

namespace AWC.SharedKernel.Interfaces
{
    public interface ICommandHandler<TCommand>
    {
        Task<Result<bool>> Handle(TCommand command);

        void SetNext(ICommandHandler<TCommand> next);
    }
}