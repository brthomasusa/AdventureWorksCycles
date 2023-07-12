using AWC.Shared.Queries.Lookups.Shared;
using gRPC.Contracts.Lookups;
using Mapster;

namespace AWC.Client.Utilities.Mapping
{
    public sealed class LookupsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // TypeAdapterConfig<TSource, TDestination>

            // Used when receiving a grpc_CompanyForDisplay to populate the ViewCompanyDetailPage
            config.NewConfig<grpc_StateProvinceCode, StateCode>()
                .Map(dest => dest.StateProvinceID, src => src.Id)
                .Map(dest => dest.StateProvinceCode, src => src.StateCode);
        }
    }
}