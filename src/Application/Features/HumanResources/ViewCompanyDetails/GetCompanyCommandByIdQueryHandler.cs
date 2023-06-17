using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyDetails
{
    public sealed class GetCompanyCommandByIdQueryHandler : IQueryHandler<GetCompanyCommandByIdRequest, GetCompanyCommandByIdResponse>
    {
        private readonly IReadRepositoryManager _repo;

        public GetCompanyCommandByIdQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<GetCompanyCommandByIdResponse>> Handle
        (
            GetCompanyCommandByIdRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<GetCompanyCommandByIdResponse> result = await _repo.CompanyReadRepository.GetCompanyCommandById(request.CompanyID);

                if (result.IsFailure)
                {
                    return Result<GetCompanyCommandByIdResponse>.Failure<GetCompanyCommandByIdResponse>(
                        new Error("GetCompanyCommandByIdQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<GetCompanyCommandByIdResponse>.Failure<GetCompanyCommandByIdResponse>(
                    new Error("GetCompanyCommandByIdQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}