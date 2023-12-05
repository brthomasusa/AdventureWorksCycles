using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewEmployeeDetails
{
    internal class GetEmployeeCommandQueryHandler : IQueryHandler<GetEmployeeCommandRequest, EmployeeGenericCommand>
    {
        private readonly IReadRepositoryManager _repo;

        public GetEmployeeCommandQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<EmployeeGenericCommand>> Handle
        (
            GetEmployeeCommandRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<EmployeeGenericCommand> getGenericCommand =
                    await _repo.EmployeeReadRepository.GetEmployeeGenericCommand(request.EmployeeID);

                if (getGenericCommand.IsFailure)
                {
                    return Result<EmployeeGenericCommand>.Failure<EmployeeGenericCommand>(
                        new Error("GetEmployeeCommandQueryHandler.Handle", getGenericCommand.Error.Message)
                    );
                }

                Result<List<PayHistoryCommand>> getPayHistoryCommand =
                    await _repo.EmployeeReadRepository.GetPayHistoryCommands(request.EmployeeID);

                if (getPayHistoryCommand.IsFailure)
                {
                    return Result<EmployeeGenericCommand>.Failure<EmployeeGenericCommand>(
                        new Error("GetEmployeeCommandQueryHandler.Handle", getPayHistoryCommand.Error.Message)
                    );
                }

                getGenericCommand.Value.PayHistories = new(getPayHistoryCommand.Value.ToList());

                Result<List<DepartmentHistoryCommand>> getDepartmentHistoryCommand =
                    await _repo.EmployeeReadRepository.GetDepartmentHistoryCommands(16);

                if (getDepartmentHistoryCommand.IsFailure)
                {
                    return Result<EmployeeGenericCommand>.Failure<EmployeeGenericCommand>(
                        new Error("GetEmployeeCommandQueryHandler.Handle", getDepartmentHistoryCommand.Error.Message)
                    );
                }

                getGenericCommand.Value.DepartmentHistories = new(getDepartmentHistoryCommand.Value.ToList());

                return getGenericCommand.Value;

            }
            catch (Exception ex)
            {
                return Result<EmployeeGenericCommand>.Failure<EmployeeGenericCommand>(
                    new Error("GetEmployeeCommandQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}