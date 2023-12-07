using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.SharedKernel.Utilities;

using Mapster;

namespace AWC.Application.Mappings.HumanResources
{
    public sealed class CompanyMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateCompanyCommand, Result<Company>>()
                .ConstructUsing(src =>
                    Company.Create
                    (
                        new CompanyID(src.CompanyID),
                        src.CompanyName!,
                        src.LegalName,
                        src.EIN!,
                        src.CompanyWebSite!,
                        src.MailAddressLine1!,
                        src.MailAddressLine2,
                        src.MailCity!,
                        src.MailStateProvinceID,
                        src.MailPostalCode!,
                        src.DeliveryAddressLine1!,
                        src.DeliveryAddressLine2,
                        src.DeliveryCity!,
                        src.DeliveryStateProvinceID,
                        src.DeliveryPostalCode!,
                        src.Telephone!,
                        src.Fax!
                    )
                );
        }
    }
}