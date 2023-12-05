using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyDepartments
{
    internal sealed class GetCompanyDepartmentsFilteredQueryHandler : IQueryHandler<GetCompanyDepartmentsFilteredRequest, PagedList<DepartmentDetails>>
    {
        private readonly IReadRepositoryManager _repo;

        public GetCompanyDepartmentsFilteredQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<PagedList<DepartmentDetails>>> Handle
        (
            GetCompanyDepartmentsFilteredRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<PagedList<DepartmentDetails>> result =
                    await _repo.CompanyReadRepository.GetCompanyDepartmentsFiltered(request.SearchCriteria);

                if (result.IsFailure)
                {
                    return Result<PagedList<DepartmentDetails>>.Failure<PagedList<DepartmentDetails>>(
                        new Error("GetCompanyDepartmentsFilteredQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<PagedList<DepartmentDetails>>.Failure<PagedList<DepartmentDetails>>(
                    new Error("GetCompanyDepartmentsFilteredQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}