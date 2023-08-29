using AWC.Shared.Queries.Lookups.HumanResources;
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

            config.NewConfig<grpc_ManagerId, ManagerId>()
                .Map(dest => dest.BusinessEntityID, src => src.BusinessEntityId)
                .Map(dest => dest.DepartmentID, src => src.DepartmentId)
                .Map(dest => dest.DepartmentName, src => src.DepartmentName)
                .Map(dest => dest.JobTitle, src => src.JobTitle)
                .Map(dest => dest.ManagerFullName, src => src.ManagerFullName);

        }
    }
}