using AWC.Application.Interfaces.Messaging;
using AWC.Core.HumanResources;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.UpdateCompany
{
    public sealed class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand, int>
    {
        private const int RETURN_VALUE = 0;
        private readonly IWriteRepositoryManager _repo;

        public UpdateCompanyCommandHandler(IWriteRepositoryManager repo)
            => _repo = repo;

        public async Task<Result<int>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Result<Company> getCompany = await _repo.CompanyAggregateRepository.GetByIdAsync(request.CompanyID);

                if (getCompany.IsFailure)
                    return Result<int>.Failure<int>(new Error("UpdateCompanyCommandHandler.Handle", getCompany.Error.Message));

                Result<Company> updateDomainObj = getCompany.Value.Update
                (
                    request.CompanyName!,
                    request.LegalName!,
                    request.EIN!,
                    request.CompanyWebSite!,
                    request.MailAddressLine1!,
                    request.MailAddressLine2,
                    request.MailCity!,
                    request.MailStateProvinceID,
                    request.MailPostalCode!,
                    request.DeliveryAddressLine1!,
                    request.DeliveryAddressLine2,
                    request.DeliveryCity!,
                    request.DeliveryStateProvinceID,
                    request.DeliveryPostalCode!,
                    request.Telephone!,
                    request.Fax!
                );

                if (updateDomainObj.IsFailure)
                    return Result<int>.Failure<int>(new Error("UpdateCompanyCommandHandler.Handle", updateDomainObj.Error.Message));

                Result<int> updateDbResult = await _repo.CompanyAggregateRepository.Update(updateDomainObj.Value);

                if (updateDbResult.IsFailure)
                    return Result<int>.Failure<int>(new Error("UpdateCompanyCommandHandler.Handle", updateDbResult.Error.Message));

                return RETURN_VALUE;
            }
            catch (Exception ex)
            {
                return Result<int>.Failure<int>(new Error("UpdateCompanyCommandHandler.Handle", Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}