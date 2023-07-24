using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewEmployeeDetails
{
    public class GetEmployeeCommandQueryHandler : IQueryHandler<GetEmployeeCommandRequest, EmployeeGenericCommand>
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
                Result<EmployeeGenericCommand> result =
                    await _repo.EmployeeReadRepository.GetEmployeeGenericCommand(request.EmployeeID);

                if (result.IsFailure)
                {
                    return Result<EmployeeGenericCommand>.Failure<EmployeeGenericCommand>(
                        new Error("GetEmployeeCommandQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

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