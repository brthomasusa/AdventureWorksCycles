using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyDepartments
{
    public sealed class GetCompanyDepartmentsQueryHandler : IQueryHandler<GetCompanyDepartmentsRequest, PagedList<GetCompanyDepartmentsResponse>>
    {
        private readonly IReadRepositoryManager _repo;

        public GetCompanyDepartmentsQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<PagedList<GetCompanyDepartmentsResponse>>> Handle
        (
            GetCompanyDepartmentsRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {

                Result<PagedList<GetCompanyDepartmentsResponse>> result =
                    await _repo.CompanyReadRepository.GetCompanyDepartments(request.PagingParameters);

                if (result.IsFailure)
                {
                    return Result<PagedList<GetCompanyDepartmentsResponse>>.Failure<PagedList<GetCompanyDepartmentsResponse>>(
                        new Error("GetCompanyDepartmentsQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<PagedList<GetCompanyDepartmentsResponse>>.Failure<PagedList<GetCompanyDepartmentsResponse>>(
                    new Error("GetCompanyDepartmentsQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}