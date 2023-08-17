using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Lookups.HumanResources.GetManagerIds
{
    public sealed class GetManagerIdsQueryHandler : IQueryHandler<GetManagerIdsRequest, List<ManagerId>>
    {
        private readonly ILookupsRepositoryManager _repoMgr;

        public GetManagerIdsQueryHandler(ILookupsRepositoryManager repo)
            => _repoMgr = repo;

        public async Task<Result<List<ManagerId>>> Handle
        (
            GetManagerIdsRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<List<ManagerId>> result = await _repoMgr.HumanResourcesLookupsRepository.ManagerIds();

                if (result.IsFailure)
                {
                    return Result<List<ManagerId>>.Failure<List<ManagerId>>(
                        new Error("GetManagerIdsQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<List<ManagerId>>.Failure<List<ManagerId>>(
                    new Error("GetManagerIdsQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}