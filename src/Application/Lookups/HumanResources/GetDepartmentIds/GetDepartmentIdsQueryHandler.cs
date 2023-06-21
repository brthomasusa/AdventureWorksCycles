using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Lookups.HumanResources.GetDepartmentIds
{
    public sealed class GetDepartmentIdsQueryHandler : IQueryHandler<GetDepartmentIdsRequest, List<DepartmentId>>
    {
        private readonly ILookupsRepositoryManager _repoMgr;

        public GetDepartmentIdsQueryHandler(ILookupsRepositoryManager repo)
            => _repoMgr = repo;

        public async Task<Result<List<DepartmentId>>> Handle
        (
            GetDepartmentIdsRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<List<DepartmentId>> result = await _repoMgr.HumanResourcesLookupsRepository.DepartmentIds();

                if (result.IsFailure)
                {
                    return Result<List<DepartmentId>>.Failure<List<DepartmentId>>(
                        new Error("GetDepartmentIdsQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<List<DepartmentId>>.Failure<List<DepartmentId>>(
                    new Error("GetDepartmentIdsQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}