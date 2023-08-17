using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyDetails
{
    public sealed class GetCompanyDetailsQueryHandler : IQueryHandler<GetCompanyDetailsRequest, CompanyDetails>
    {
        private readonly IReadRepositoryManager _repo;

        public GetCompanyDetailsQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<CompanyDetails>> Handle
        (
            GetCompanyDetailsRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<CompanyDetails> result = await _repo.CompanyReadRepository.GetCompanyDetails(request.CompanyID);

                if (result.IsFailure)
                {
                    return Result<CompanyDetails>.Failure<CompanyDetails>(
                        new Error("GetCompanyDetailQueryHandler.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<CompanyDetails>.Failure<CompanyDetails>(
                    new Error("GetCompanyDetailQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}