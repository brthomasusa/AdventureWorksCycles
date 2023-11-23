using AWC.Application.Interfaces.Messaging;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
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
                Result<Company> result = Company.Create(
                    new CompanyID(request.CompanyID),
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

                if (result.IsFailure)
                    return Result<int>.Failure<int>(new Error("UpdateCompanyCommandHandler.Handle", result.Error.Message));

                Result<int> updateDbResult = await _repo.CompanyAggregateRepository.Update(result.Value);

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