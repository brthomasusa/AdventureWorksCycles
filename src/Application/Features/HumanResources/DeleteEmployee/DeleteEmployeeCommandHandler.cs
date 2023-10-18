using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.DeleteEmployee
{
    public sealed class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand, int>
    {
        private const int RETURN_VALUE = 0;
        private readonly IWriteRepositoryManager _repo;

        public DeleteEmployeeCommandHandler(IWriteRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<int>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Result<int> deleteDbResult = await _repo.EmployeeAggregateRepository.Delete(request.BusinessEntityID);

                if (deleteDbResult.IsFailure)
                    return Result<int>.Failure<int>(new Error("DeleteEmployeeCommandHandler.Handle", deleteDbResult.Error.Message));

                return RETURN_VALUE;
            }
            catch (Exception ex)
            {
                return Result<int>.Failure<int>(new Error("DeleteEmployeeCommandHandler.Handle", Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}