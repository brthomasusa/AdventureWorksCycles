using AWC.Shared.Queries.HumanResources;
using gRPC.Contracts.HumanResources;
using Mapster;
using GoogleDateTime = Google.Protobuf.WellKnownTypes.Timestamp;

namespace AWC.Client.Utilities.Mapping
{
    public sealed class EmployeeAggregateMappingConfig : IRegister
    {
        void IRegister.Register(TypeAdapterConfig config)
        {
            /*
                    TypeAdapterConfig<TSource, TDestination>   
            */

            config.NewConfig<grpc_EmployeeForDisplay, EmployeeDetails>()
                .Map(dest => dest.Title, src => string.IsNullOrEmpty(src.Title) ? null : src.Title)
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? null : src.MiddleName)
                .Map(dest => dest.Suffix, src => string.IsNullOrEmpty(src.Suffix) ? null : src.Suffix)
                .Map(dest => dest.AddressLine2, src => string.IsNullOrEmpty(src.AddressLine2) ? null : src.AddressLine2)
                .Map(dest => dest.BirthDate, src => src.BirthDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.HireDate, src => src.HireDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.DepartmentHistories, src => src.DepartmentHistories)
                .Map(dest => dest.PayHistories, src => src.PayHistories);

            config.NewConfig<AWC.Shared.Commands.HumanResources.EmployeeGenericCommand, grpc_EmployeeGenericCommand>()
                .Map(dest => dest.Title, src => string.IsNullOrEmpty(src.Title) ? string.Empty : src.Title)
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? string.Empty : src.MiddleName)
                .Map(dest => dest.Suffix, src => string.IsNullOrEmpty(src.Suffix) ? string.Empty : src.Suffix)
                .Map(dest => dest.PhoneNumberTypeId, src => src.PhoneNumberTypeID)
                .Map(dest => dest.AddressLine2, src => string.IsNullOrEmpty(src.AddressLine2) ? string.Empty : src.AddressLine2)
                .Map(dest => dest.BirthDate, src => GoogleDateTime.FromDateTimeOffset(src.BirthDate))
                .Map(dest => dest.HireDate, src => GoogleDateTime.FromDateTimeOffset(src.HireDate));

            config.NewConfig<grpc_EmployeeGenericCommand, EmployeeGenericCommand>()
                .Map(dest => dest.Title, src => string.IsNullOrEmpty(src.Title) ? null : src.Title)
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? null : src.MiddleName)
                .Map(dest => dest.Suffix, src => string.IsNullOrEmpty(src.Suffix) ? null : src.Suffix)
                .Map(dest => dest.AddressLine2, src => string.IsNullOrEmpty(src.AddressLine2) ? null : src.AddressLine2)
                .Map(dest => dest.BirthDate, src => src.BirthDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.HireDate, src => src.HireDate.ToDateTime().ToLocalTime());

            config.NewConfig<grpc_EmployeeListItem, EmployeeListItem>()
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? null : src.MiddleName)
                .Map(dest => dest.ManagerName, src => string.IsNullOrEmpty(src.ManagerName) ? null : src.ManagerName);

            // Commands
            config.NewConfig<grpc_DepartmentHistoryCommand, AWC.Shared.Commands.HumanResources.DepartmentHistoryCommand>()
                .Map(dest => dest.BusinessEntityID, src => src.BusinessEntityId)
                .Map(dest => dest.DepartmentID, src => src.DepartmentId)
                .Map(dest => dest.ShiftID, src => src.ShiftId)
                .Map(dest => dest.StartDate, src => src.StartDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.EndDate, src => src.EndDate.ToDateTime().ToLocalTime());

            config.NewConfig<AWC.Shared.Commands.HumanResources.DepartmentHistoryCommand, grpc_DepartmentHistoryCommand>()
                .Map(dest => dest.BusinessEntityId, src => src.BusinessEntityID)
                .Map(dest => dest.DepartmentId, src => src.DepartmentID)
                .Map(dest => dest.ShiftId, src => src.ShiftID)
                .Map(dest => dest.StartDate, src => GoogleDateTime.FromDateTimeOffset(src.StartDate))
                .Map(dest => dest.EndDate, src => src.EndDate != null ? GoogleDateTime.FromDateTimeOffset(src.EndDate.Value) : GoogleDateTime.FromDateTimeOffset(new DateTimeOffset()));

            // Commands
            config.NewConfig<grpc_PayHistoryCommand, AWC.Shared.Commands.HumanResources.PayHistoryCommand>()
                .Map(dest => dest.BusinessEntityID, src => src.BusinessEntityId)
                .Map(dest => dest.RateChangeDate, src => src.RateChangeDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.Rate, src => (decimal)src.Rate)
                .Map(dest => dest.PayFrequency, src => src.PayFrequency);

            config.NewConfig<AWC.Shared.Commands.HumanResources.PayHistoryCommand, grpc_PayHistoryCommand>()
                .Map(dest => dest.BusinessEntityId, src => src.BusinessEntityID)
                .Map(dest => dest.RateChangeDate, src => GoogleDateTime.FromDateTimeOffset(src.RateChangeDate))
                .Map(dest => dest.Rate, src => (double)src.Rate)
                .Map(dest => dest.PayFrequency, src => src.PayFrequency);

            // Query
            config.NewConfig<grpc_DepartmentHistory, AWC.Shared.Queries.HumanResources.DepartmentHistory>()
                .Map(dest => dest.BusinessEntityID, src => src.BusinessEntityId)
                .Map(dest => dest.Department, src => src.Department)
                .Map(dest => dest.Shift, src => src.Shift)
                .Map(dest => dest.StartDate, src => src.StartDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.EndDate, src => src.EndDate.ToDateTime().ToLocalTime());

            // Query
            config.NewConfig<grpc_PayHistory, AWC.Shared.Queries.HumanResources.PayHistory>()
                .Map(dest => dest.BusinessEntityID, src => src.BusinessEntityId)
                .Map(dest => dest.RateChangeDate, src => src.RateChangeDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.Rate, src => (decimal)src.Rate)
                .Map(dest => dest.PayFrequency, src => src.PayFrequency);
        }
    }
}
