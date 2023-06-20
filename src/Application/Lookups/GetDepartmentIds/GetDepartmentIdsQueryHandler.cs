using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.Lookups;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Lookups.GetDepartmentIds
{
    public sealed class GetDepartmentIdsQueryHandler : IQueryHandler<GetDepartmentIdsRequest, List<DepartmentId>>
    {
        private readonly ILookupsRepositoryManager _repo;

        public GetDepartmentIdsQueryHandler(ILookupsRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<List<DepartmentId>>> Handle
        (
            GetDepartmentIdsRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<List<DepartmentId>> result = await _repo.LookupsRepository.DepartmentIds();

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