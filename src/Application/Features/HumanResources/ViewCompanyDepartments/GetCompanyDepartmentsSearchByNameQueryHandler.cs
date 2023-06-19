using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyDepartments
{
    public sealed class GetCompanyDepartmentsSearchByNameQueryHandler : IQueryHandler<GetCompanyDepartmentsSearchByNameRequest, PagedList<GetCompanyDepartmentsResponse>>
    {
        private readonly IReadRepositoryManager _repo;

        public GetCompanyDepartmentsSearchByNameQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<PagedList<GetCompanyDepartmentsResponse>>> Handle
        (
            GetCompanyDepartmentsSearchByNameRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {

                Result<PagedList<GetCompanyDepartmentsResponse>> result =
                    await _repo.CompanyReadRepository.GetCompanyDepartmentsSearchByName(request.DepartmentName, request.PagingParameters);

                if (result.IsFailure)
                {
                    return Result<PagedList<GetCompanyDepartmentsResponse>>.Failure<PagedList<GetCompanyDepartmentsResponse>>(
                        new Error("GetCompanyDepartmentsSearchByNameQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<PagedList<GetCompanyDepartmentsResponse>>.Failure<PagedList<GetCompanyDepartmentsResponse>>(
                    new Error("GetCompanyDepartmentsSearchByNameQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}