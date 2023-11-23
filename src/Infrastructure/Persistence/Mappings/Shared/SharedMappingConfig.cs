using Mapster;

namespace AWC.Infrastructure.Persistence.Mappings.Shared
{
    public sealed class SharedMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // TypeAdapterConfig<TSource, TDestination> ((DateTime?)null)

            _ = config.NewConfig<AWC.Core.Entities.Shared.Address, AWC.Infrastructure.Persistence.DataModels.Person.Address>()
            .Map(dest => dest.AddressID, src => src.Id.Value)
            .Map(dest => dest.AddressLine1, src => src.Location.AddressLine1)
            .Map(dest => dest.AddressLine2, src => src.Location.AddressLine2)
            .Map(dest => dest.City, src => src.Location.City)
            .Map(dest => dest.StateProvinceID, src => src.Location.StateProvinceID)
            .Map(dest => dest.PostalCode, src => src.Location.PostalCode);

            _ = config.NewConfig<AWC.Core.Entities.Shared.PersonPhone, AWC.Infrastructure.Persistence.DataModels.Person.PersonPhone>()
            .Map(dest => dest.BusinessEntityID, src => 0)
            .Map(dest => dest.PhoneNumber, src => src.Telephone.Value)
            .Map(dest => dest.PhoneNumberTypeID, src => (int)src.PhoneNumberType);

            _ = config.NewConfig<AWC.Core.Entities.Shared.PersonEmailAddress, AWC.Infrastructure.Persistence.DataModels.Person.EmailAddress>()
            .Map(dest => dest.BusinessEntityID, src => 0)
            .Map(dest => dest.EmailAddressID, src => src.EmailAddressID.Value)
            .Map(dest => dest.MailAddress, src => src.EmailAddress.Value);
        }
    }
}