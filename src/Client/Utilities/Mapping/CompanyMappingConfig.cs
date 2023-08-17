using AWC.Shared.Queries.HumanResources;
using gRPC.Contracts.HumanResources;
using Mapster;

namespace AWC.Client.Utilities.Mapping
{
    public sealed class CompanyMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // TypeAdapterConfig<TSource, TDestination>

            // Used when receiving a grpc_CompanyForDisplay to populate the ViewCompanyDetailPage
            config.NewConfig<grpc_CompanyForDisplay, CompanyDetails>()
                .Map(dest => dest.LegalName, src => string.IsNullOrEmpty(src.LegalName) ? null : src.LegalName)
                .Map(dest => dest.CompanyWebSite, src => string.IsNullOrEmpty(src.CompanyWebSite) ? null : src.CompanyWebSite)
                .Map(dest => dest.MailAddressLine2, src => string.IsNullOrEmpty(src.MailAddressLine2) ? null : src.MailAddressLine2)
                .Map(dest => dest.DeliveryAddressLine2, src => string.IsNullOrEmpty(src.DeliveryAddressLine2) ? null : src.DeliveryAddressLine2);

            // Used when sending a CompanyGenericCommand to the server api
            config.NewConfig<CompanyGenericCommand, grpc_CompanyGenericCommand>()
                .Map(dest => dest.CompanyId, src => src.CompanyID)
                .Map(dest => dest.LegalName, src => string.IsNullOrEmpty(src.LegalName) ? string.Empty : src.LegalName)
                .Map(dest => dest.CompanyWebSite, src => string.IsNullOrEmpty(src.CompanyWebSite) ? string.Empty : src.CompanyWebSite)
                .Map(dest => dest.MailAddressLine2, src => string.IsNullOrEmpty(src.MailAddressLine2) ? string.Empty : src.MailAddressLine2)
                .Map(dest => dest.DeliveryAddressLine2, src => string.IsNullOrEmpty(src.DeliveryAddressLine2) ? string.Empty : src.DeliveryAddressLine2);

            // Used when receiving a grpc_CompanyGenericCommand to populate the CompnayUpdatePage
            config.NewConfig<grpc_CompanyGenericCommand, CompanyGenericCommand>()
                .Map(dest => dest.LegalName, src => string.IsNullOrEmpty(src.LegalName) ? string.Empty : src.LegalName)
                .Map(dest => dest.CompanyWebSite, src => string.IsNullOrEmpty(src.CompanyWebSite) ? string.Empty : src.CompanyWebSite)
                .Map(dest => dest.MailAddressLine2, src => string.IsNullOrEmpty(src.MailAddressLine2) ? string.Empty : src.MailAddressLine2)
                .Map(dest => dest.DeliveryAddressLine2, src => string.IsNullOrEmpty(src.DeliveryAddressLine2) ? string.Empty : src.DeliveryAddressLine2);

            // Used when receiving a grpc_ompanyGenericCommand to populate the CompnayUpdatePage
            config.NewConfig<grpc_Department, DepartmentDetails>()
                .Map(dest => dest.DepartmentID, src => src.DepartmentId)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.GroupName, src => src.GroupName)
                .Map(dest => dest.ModifiedDate, src => src.ModifiedDate.ToDateTime().ToLocalTime());

        }
    }
}