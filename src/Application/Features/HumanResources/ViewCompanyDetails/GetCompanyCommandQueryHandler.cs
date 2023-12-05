using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyDetails
{
    internal sealed class GetCompanyCommandQueryHandler : IQueryHandler<GetCompanyCommandRequest, CompanyGenericCommand>
    {
        private readonly IReadRepositoryManager _repo;

        public GetCompanyCommandQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<CompanyGenericCommand>> Handle
        (
            GetCompanyCommandRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<CompanyGenericCommand> result = await _repo.CompanyReadRepository.GetCompanyCommand(request.CompanyID);

                if (result.IsFailure)
                {
                    return Result<CompanyGenericCommand>.Failure<CompanyGenericCommand>(
                        new Error("GetCompanyCommandQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<CompanyGenericCommand>.Failure<CompanyGenericCommand>(
                    new Error("GetCompanyCommandQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}