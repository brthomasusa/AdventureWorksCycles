using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewEmployees
{
    internal sealed class GetEmployeeListItemsQueryHandler : IQueryHandler<GetEmployeeListItemsRequest, PagedList<EmployeeListItem>>
    {
        private readonly IReadRepositoryManager _repo;

        public GetEmployeeListItemsQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<PagedList<EmployeeListItem>>> Handle
        (
            GetEmployeeListItemsRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {

                Result<PagedList<EmployeeListItem>> result =
                    await _repo.EmployeeReadRepository.GetEmployeeListItemsSearchByLastName(request.SearchCriteria);

                if (result.IsFailure)
                {
                    return Result<PagedList<EmployeeListItem>>.Failure<PagedList<EmployeeListItem>>(
                        new Error("GGetEmployeeListItemsQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<PagedList<EmployeeListItem>>.Failure<PagedList<EmployeeListItem>>(
                    new Error("GetEmployeeListItemsQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}