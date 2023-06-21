using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewEmployees
{
    public sealed class GetEmployeeListItemsQueryHandler : IQueryHandler<GetEmployeeListItemsRequest, PagedList<EmployeeListItemResponse>>
    {
        private readonly IReadRepositoryManager _repo;

        public GetEmployeeListItemsQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<PagedList<EmployeeListItemResponse>>> Handle
        (
            GetEmployeeListItemsRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {

                Result<PagedList<EmployeeListItemResponse>> result =
                    await _repo.EmployeeReadRepository.GetEmployeeListItemsSearchByLastName(request.LastName, request.PagingParameters);

                if (result.IsFailure)
                {
                    return Result<PagedList<EmployeeListItemResponse>>.Failure<PagedList<EmployeeListItemResponse>>(
                        new Error("GGetEmployeeListItemsQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<PagedList<EmployeeListItemResponse>>.Failure<PagedList<EmployeeListItemResponse>>(
                    new Error("GetEmployeeListItemsQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}