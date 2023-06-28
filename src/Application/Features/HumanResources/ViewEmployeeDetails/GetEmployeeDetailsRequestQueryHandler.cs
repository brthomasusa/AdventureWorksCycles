using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewEmployeeDetails
{
    public sealed class GetEmployeeDetailsRequestQueryHandler : IQueryHandler<GetEmployeeDetailsRequest, EmployeeDetails>
    {
        private readonly IReadRepositoryManager _repo;

        public GetEmployeeDetailsRequestQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<EmployeeDetails>> Handle
        (
            GetEmployeeDetailsRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<EmployeeDetails> result =
                    await _repo.EmployeeReadRepository.GetEmployeeDetailsByIdWithAllInfo(request.EmployeeID);

                if (result.IsFailure)
                {
                    return Result<EmployeeDetails>.Failure<EmployeeDetails>(
                        new Error("GetEmployeeDetailsByIdWithAllInfoQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<EmployeeDetails>.Failure<EmployeeDetails>(
                    new Error("GetEmployeeDetailsByIdWithAllInfoQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}