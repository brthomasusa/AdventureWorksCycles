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
                .Map(dest => dest.StateProvinceCode, src => src.StateCode)
                .Map(dest => dest.StateProvinceName, src => src.StateProvinceName);

            config.NewConfig<grpc_ManagerId, ManagerId>()
                .Map(dest => dest.BusinessEntityID, src => src.BusinessEntityId)
                .Map(dest => dest.DepartmentID, src => src.DepartmentId)
                .Map(dest => dest.DepartmentName, src => src.DepartmentName)
                .Map(dest => dest.JobTitle, src => src.JobTitle)
                .Map(dest => dest.ManagerFullName, src => src.ManagerFullName);

            config.NewConfig<grpc_DepartmentId, DepartmentId>()
                .Map(dest => dest.DepartmentID, src => src.DepartmentId)
                .Map(dest => dest.DepartmentName, src => src.Name);

            config.NewConfig<grpc_ShiftId, ShiftId>()
                .Map(dest => dest.ShiftID, src => src.ShiftId)
                .Map(dest => dest.ShiftName, src => src.Name);
        }
    }
}