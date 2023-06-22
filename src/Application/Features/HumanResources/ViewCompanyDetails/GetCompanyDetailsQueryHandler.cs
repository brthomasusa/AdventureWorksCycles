using AWC.Application.Interfaces.Messaging;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.ViewCompanyDetails
{
    public sealed class GetCompanyDetailsQueryHandler : IQueryHandler<GetCompanyDetailsRequest, CompanyDetailsForDisplay>
    {
        private readonly IReadRepositoryManager _repo;

        public GetCompanyDetailsQueryHandler(IReadRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<CompanyDetailsForDisplay>> Handle
        (
            GetCompanyDetailsRequest request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                Result<CompanyDetailsForDisplay> result = await _repo.CompanyReadRepository.GetCompanyDetails(request.CompanyID);

                if (result.IsFailure)
                {
                    return Result<CompanyDetailsForDisplay>.Failure<CompanyDetailsForDisplay>(
                        new Error("GetCompanyDetailQueryHandler.Handle.Handle", result.Error.Message)
                    );
                }

                return result.Value;

            }
            catch (Exception ex)
            {
                return Result<CompanyDetailsForDisplay>.Failure<CompanyDetailsForDisplay>(
                    new Error("GetCompanyDetailQueryHandler.Handle", Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}