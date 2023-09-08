using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using gRPC.Contracts.Lookups;
using Mapster;

namespace AWC.Server.Mapping.Lookups
{
    public sealed class LookupsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // TypeAdapterConfig<TSource, TDestination>

            config.NewConfig<StateCode, grpc_StateProvinceCode>()
                .Map(dest => dest.Id, src => src.StateProvinceID)
                .Map(dest => dest.StateCode, src => src.StateProvinceCode)
                .Map(dest => dest.StateProvinceName, src => src.StateProvinceName);

            config.NewConfig<ManagerId, grpc_ManagerId>()
                .Map(dest => dest.BusinessEntityId, src => src.BusinessEntityID)
                .Map(dest => dest.DepartmentId, src => src.DepartmentID)
                .Map(dest => dest.DepartmentName, src => src.DepartmentName)
                .Map(dest => dest.JobTitle, src => src.JobTitle)
                .Map(dest => dest.ManagerFullName, src => src.ManagerFullName);

            config.NewConfig<DepartmentId, grpc_DepartmentId>()
                .Map(dest => dest.DepartmentId, src => src.DepartmentID)
                .Map(dest => dest.Name, src => src.DepartmentName);

            config.NewConfig<ShiftId, grpc_ShiftId>()
                .Map(dest => dest.ShiftId, src => src.ShiftID)
                .Map(dest => dest.Name, src => src.ShiftName);
        }
    }
}