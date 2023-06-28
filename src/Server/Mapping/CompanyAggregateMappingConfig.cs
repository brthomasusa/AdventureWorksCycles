using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Shared;
using Mapster;
using GoogleDateTime = Google.Protobuf.WellKnownTypes.Timestamp;

namespace REA.Accounting.Server.Mapping
{
    public sealed class CompanyAggregateMappingConfig : IRegister
    {
        void IRegister.Register(TypeAdapterConfig config)
        {
            /*
                    TypeAdapterConfig<TSource, TDestination>   
            */

            config.NewConfig<grpc_CompanyGenericCommand, UpdateCompanyCommand>()
                .Map(dest => dest.LegalName, src => string.IsNullOrEmpty(src.LegalName) ? null : src.LegalName)
                .Map(dest => dest.CompanyWebSite, src => string.IsNullOrEmpty(src.CompanyWebSite) ? null : src.CompanyWebSite)
                .Map(dest => dest.MailAddressLine2, src => string.IsNullOrEmpty(src.MailAddressLine2) ? null : src.MailAddressLine2)
                .Map(dest => dest.DeliveryAddressLine2, src => string.IsNullOrEmpty(src.DeliveryAddressLine2) ? null : src.DeliveryAddressLine2);

            config.NewConfig<CompanyDetails, grpc_CompanyForDisplay>()
                .Map(dest => dest.LegalName, src => string.IsNullOrEmpty(src.LegalName) ? string.Empty : src.LegalName)
                .Map(dest => dest.CompanyWebSite, src => string.IsNullOrEmpty(src.CompanyWebSite) ? string.Empty : src.CompanyWebSite)
                .Map(dest => dest.MailAddressLine2, src => string.IsNullOrEmpty(src.MailAddressLine2) ? string.Empty : src.MailAddressLine2)
                .Map(dest => dest.DeliveryAddressLine2, src => string.IsNullOrEmpty(src.DeliveryAddressLine2) ? string.Empty : src.DeliveryAddressLine2);

            config.NewConfig<CompanyGenericCommand, grpc_CompanyGenericCommand>()
                .Map(dest => dest.LegalName, src => string.IsNullOrEmpty(src.LegalName) ? string.Empty : src.LegalName)
                .Map(dest => dest.CompanyWebSite, src => string.IsNullOrEmpty(src.CompanyWebSite) ? string.Empty : src.CompanyWebSite)
                .Map(dest => dest.MailAddressLine2, src => string.IsNullOrEmpty(src.MailAddressLine2) ? string.Empty : src.MailAddressLine2)
                .Map(dest => dest.DeliveryAddressLine2, src => string.IsNullOrEmpty(src.DeliveryAddressLine2) ? string.Empty : src.DeliveryAddressLine2);

            config.NewConfig<DepartmentDetails, grpc_Department>()
                .Map(dest => dest.ModifiedDate, src => GoogleDateTime.FromDateTimeOffset(src.ModifiedDate));

            config.NewConfig<ShiftDetails, grpc_Shift>()
                .Map(dest => dest.ModifiedDate, src => GoogleDateTime.FromDateTimeOffset(src.ModifiedDate));

            // Protobuf message field values can not be null so they are
            // set to string.Empty. Here we are setting them back to null
            // as a query will use the null condition to ignore filtering

            config.NewConfig<grpc_StringSearchCriteria, StringSearchCriteria>()
                .Map(dest => dest.SearchCriteria, src => string.IsNullOrEmpty(src.SearchCriteria) ? null : src.SearchCriteria)
                .Map(dest => dest.SearchField, src => string.IsNullOrEmpty(src.SearchField) ? null : src.SearchField)
                .Map(dest => dest.OrderBy, src => string.IsNullOrEmpty(src.OrderBy) ? null : src.OrderBy)
                .Map(dest => dest.PageNumber, src => src.PageNumber)
                .Map(dest => dest.PageSize, src => src.PageSize);
        }
    }
}
