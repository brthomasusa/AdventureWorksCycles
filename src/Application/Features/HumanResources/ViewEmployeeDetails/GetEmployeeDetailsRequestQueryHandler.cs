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
                Result<EmployeeDetails> getEmployeeDetails =
                    await _repo.EmployeeReadRepository.GetEmployeeDetails(request.EmployeeID);

                if (getEmployeeDetails.IsFailure)
                {
                    return Result<EmployeeDetails>.Failure<EmployeeDetails>(
                        new Error("GetEmployeeDetailsRequestQueryHandler.Handle", getEmployeeDetails.Error.Message)
                    );
                }

                Result<List<PayHistory>> getPayHistory =
                    await _repo.EmployeeReadRepository.GetPayHistories(request.EmployeeID);

                if (getPayHistory.IsFailure)
                {
                    return Result<EmployeeDetails>.Failure<EmployeeDetails>(
                        new Error("GetEmployeeDetailsRequestQueryHandler.Handle", getPayHistory.Error.Message)
                    );
                }

                getEmployeeDetails.Value.PayHistories = new(getPayHistory.Value.ToList());

                Result<List<DepartmentHistory>> getDepartmentHistory =
                    await _repo.EmployeeReadRepository.GetDepartmentHistories(request.EmployeeID);

                if (getDepartmentHistory.IsFailure)
                {
                    return Result<EmployeeDetails>.Failure<EmployeeDetails>(
                        new Error("GetEmployeeDetailsRequestQueryHandler.Handle", getDepartmentHistory.Error.Message)
                    );
                }

                getEmployeeDetails.Value.DepartmentHistories = new(getDepartmentHistory.Value.ToList());

                return getEmployeeDetails.Value;

            }
            catch (Exception ex)
            {
                return Result<EmployeeDetails>.Failure<EmployeeDetails>(
                    new Error("GetEmployeeDetailsRequestQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}
