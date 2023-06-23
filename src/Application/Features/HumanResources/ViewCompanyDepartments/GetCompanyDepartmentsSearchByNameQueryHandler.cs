using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyDepartments
{
    public sealed class GetCompanyDepartmentsSearchByNameQueryHandler : IQueryHandler<GetCompanyDepartmentsSearchByNameRequest, PagedList<DepartmentDetails>>
    {
        private readonly IReadRepositoryManager _repo;

        public GetCompanyDepartmentsSearchByNameQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<PagedList<DepartmentDetails>>> Handle
        (
            GetCompanyDepartmentsSearchByNameRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {

                Result<PagedList<DepartmentDetails>> result =
                    await _repo.CompanyReadRepository.GetCompanyDepartmentsSearchByName(request.DepartmentName, request.PagingParameters);

                if (result.IsFailure)
                {
                    return Result<PagedList<DepartmentDetails>>.Failure<PagedList<DepartmentDetails>>(
                        new Error("GetCompanyDepartmentsSearchByNameQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<PagedList<DepartmentDetails>>.Failure<PagedList<DepartmentDetails>>(
                    new Error("GetCompanyDepartmentsSearchByNameQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}