using CompanyDataModel = AWC.Infrastructure.Persistence.DataModels.HumanResources.Company;
using CompanyDomainModel = AWC.Core.HumanResources.Company;
using Mapster;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public sealed class CompanyMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            /*
                    TypeAdapterConfig<TSource, TDestination>   
            */

            config.NewConfig<CompanyDomainModel, CompanyDataModel>()
                .Map(dest => dest.CompanyID, src => src.Id)
                .Map(dest => dest.CompanyName, src => src.CompanyName)
                .Map(dest => dest.LegalName, src => src.LegalName)
                .Map(dest => dest.EIN, src => src.EIN)
                .Map(dest => dest.WebsiteUrl, src => src.CompanyWebSite)
                .Map(dest => dest.MailAddressLine1, src => src.PostalAddress.AddressLine1)
                .Map(dest => dest.MailAddressLine2, src => src.PostalAddress.AddressLine2)
                .Map(dest => dest.MailCity, src => src.PostalAddress.City)
                .Map(dest => dest.MailStateProvinceID, src => src.PostalAddress.StateProvinceID)
                .Map(dest => dest.MailPostalCode, src => src.PostalAddress.Zipcode)
                .Map(dest => dest.DeliveryAddressLine1, src => src.DeliveryAddress.AddressLine1)
                .Map(dest => dest.DeliveryAddressLine2, src => src.DeliveryAddress.AddressLine2)
                .Map(dest => dest.DeliveryCity, src => src.DeliveryAddress.City)
                .Map(dest => dest.DeliveryStateProvinceID, src => src.DeliveryAddress.StateProvinceID)
                .Map(dest => dest.DeliveryPostalCode, src => src.DeliveryAddress.Zipcode)
                .Map(dest => dest.Telephone, src => src.Telephone)
                .Map(dest => dest.Fax, src => src.Fax);
        }
    }
}