using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyShifts
{
    public class GetCompanyShiftsQueryHandler : IQueryHandler<GetCompanyShiftsRequest, PagedList<ShiftDetails>>
    {
        private readonly IReadRepositoryManager _repo;

        public GetCompanyShiftsQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<PagedList<ShiftDetails>>> Handle
        (
            GetCompanyShiftsRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {

                Result<PagedList<ShiftDetails>> result =
                    await _repo.CompanyReadRepository.GetCompanyShifts(request.PagingParameters);

                if (result.IsFailure)
                {
                    return Result<PagedList<ShiftDetails>>.Failure<PagedList<ShiftDetails>>(
                        new Error("GetCompanyShiftsQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<PagedList<ShiftDetails>>.Failure<PagedList<ShiftDetails>>(
                    new Error("GetCompanyShiftsQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}