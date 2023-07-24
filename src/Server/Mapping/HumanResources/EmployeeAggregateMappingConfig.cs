using AWC.Shared.Queries.HumanResources;
using gRPC.Contracts.HumanResources;
using Mapster;
using GoogleDateTime = Google.Protobuf.WellKnownTypes.Timestamp;

namespace AWC.Server.Mapping.HumanResources
{
    public sealed class EmployeeAggregateMappingConfig : IRegister
    {
        void IRegister.Register(TypeAdapterConfig config)
        {
            /*
                    TypeAdapterConfig<TSource, TDestination>   
            */

            config.NewConfig<EmployeeDetails, grpc_EmployeeForDisplay>()
                .Map(dest => dest.Title, src => string.IsNullOrEmpty(src.Title) ? string.Empty : src.Title)
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? string.Empty : src.MiddleName)
                .Map(dest => dest.Suffix, src => string.IsNullOrEmpty(src.Suffix) ? string.Empty : src.Suffix)
                .Map(dest => dest.AddressLine2, src => string.IsNullOrEmpty(src.AddressLine2) ? string.Empty : src.AddressLine2)
                .Map(dest => dest.BirthDate, src => GoogleDateTime.FromDateTimeOffset(src.BirthDate))
                .Map(dest => dest.HireDate, src => GoogleDateTime.FromDateTimeOffset(src.HireDate))
                .Map(dest => dest.PayRate, src => Decimal.ToDouble(src.PayRate));

            config.NewConfig<EmployeeGenericCommand, grpc_EmployeeGenericCommand>()
                .Map(dest => dest.Title, src => string.IsNullOrEmpty(src.Title) ? string.Empty : src.Title)
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? string.Empty : src.MiddleName)
                .Map(dest => dest.Suffix, src => string.IsNullOrEmpty(src.Suffix) ? string.Empty : src.Suffix)
                .Map(dest => dest.AddressLine2, src => string.IsNullOrEmpty(src.AddressLine2) ? string.Empty : src.AddressLine2)
                .Map(dest => dest.BirthDate, src => GoogleDateTime.FromDateTimeOffset(src.BirthDate))
                .Map(dest => dest.HireDate, src => GoogleDateTime.FromDateTimeOffset(src.HireDate))
                .Map(dest => dest.PayRate, src => Decimal.ToDouble(src.PayRate));

            config.NewConfig<grpc_EmployeeGenericCommand, EmployeeGenericCommand>()
                .Map(dest => dest.Title, src => string.IsNullOrEmpty(src.Title) ? null : src.Title)
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? null : src.MiddleName)
                .Map(dest => dest.Suffix, src => string.IsNullOrEmpty(src.Suffix) ? null : src.Suffix)
                .Map(dest => dest.AddressLine2, src => string.IsNullOrEmpty(src.AddressLine2) ? null : src.AddressLine2)
                .Map(dest => dest.BirthDate, src => src.BirthDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.HireDate, src => src.HireDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.PayRate, src => (decimal)src.PayRate);

            config.NewConfig<EmployeeListItem, grpc_EmployeeListItem>()
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? string.Empty : src.MiddleName)
                .Map(dest => dest.ManagerName, src => string.IsNullOrEmpty(src.ManagerName) ? string.Empty : src.ManagerName);

        }
    }
}
