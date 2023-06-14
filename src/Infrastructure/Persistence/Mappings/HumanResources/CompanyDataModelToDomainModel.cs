using AWC.SharedKernel.Utilities;
using CompanyDataModel = AWC.Infrastructure.Persistence.DataModels.HumanResources.Company;
using CompanyDomainModel = AWC.Core.HumanResources.Company;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public static class CompanyDataModelToDomainModel
    {
        public static Result<CompanyDomainModel> MapToCompanyDomainObject(this CompanyDataModel dataModel)
        {
            Result<CompanyDomainModel> result = CompanyDomainModel.Create
            (
                dataModel.CompanyID,
                dataModel.CompanyName!,
                dataModel.LegalName!,
                dataModel.EIN!,
                dataModel.WebsiteUrl!,
                dataModel.MailAddressLine1!,
                dataModel.DeliveryAddressLine2,
                dataModel.MailCity!,
                dataModel.MailStateProvinceID,
                dataModel.MailPostalCode!,
                dataModel.DeliveryAddressLine1!,
                dataModel.DeliveryAddressLine2,
                dataModel.DeliveryCity!,
                dataModel.DeliveryStateProvinceID,
                dataModel.DeliveryPostalCode!,
                dataModel.Telephone!,
                dataModel.Fax!
            );

            if (result.IsFailure)
                return Result<CompanyDomainModel>.Failure<CompanyDomainModel>(new Error("CompanyDataModelToDomainModel.MapToCompanyDomainObject", result.Error.Message));

            return result.Value;
        }
    }
}