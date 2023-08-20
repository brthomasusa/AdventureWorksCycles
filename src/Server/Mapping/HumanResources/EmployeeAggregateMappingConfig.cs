using AWC.Shared.Queries.HumanResources;
using gRPC.Contracts.HumanResources;
using Mapster;
using GoogleDateTime = Google.Protobuf.WellKnownTypes.Timestamp;
using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Features.HumanResources.UpdateEmployee;

namespace AWC.Server.Mapping.HumanResources
{
    public sealed class EmployeeAggregateMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            /*
                    TypeAdapterConfig<TSource, TDestination>   
            */

            // To the UI, used to display employee details
            config.NewConfig<EmployeeDetails, grpc_EmployeeForDisplay>()
                .Map(dest => dest.Title, src => string.IsNullOrEmpty(src.Title) ? string.Empty : src.Title)
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? string.Empty : src.MiddleName)
                .Map(dest => dest.Suffix, src => string.IsNullOrEmpty(src.Suffix) ? string.Empty : src.Suffix)
                .Map(dest => dest.AddressLine2, src => string.IsNullOrEmpty(src.AddressLine2) ? string.Empty : src.AddressLine2)
                .Map(dest => dest.BirthDate, src => GoogleDateTime.FromDateTimeOffset(src.BirthDate))
                .Map(dest => dest.HireDate, src => GoogleDateTime.FromDateTimeOffset(src.HireDate))
                .Map(dest => dest.DepartmentHistories, src => src.DepartmentHistories!.Adapt<List<grpc_DepartmentHistory>>());

            // To the UI, used to populate employee update page
            config.NewConfig<EmployeeGenericCommand, grpc_EmployeeGenericCommand>()
                .Map(dest => dest.Title, src => string.IsNullOrEmpty(src.Title) ? string.Empty : src.Title)
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? string.Empty : src.MiddleName)
                .Map(dest => dest.Suffix, src => string.IsNullOrEmpty(src.Suffix) ? string.Empty : src.Suffix)
                .Map(dest => dest.AddressLine2, src => string.IsNullOrEmpty(src.AddressLine2) ? string.Empty : src.AddressLine2)
                .Map(dest => dest.BirthDate, src => GoogleDateTime.FromDateTimeOffset(src.BirthDate))
                .Map(dest => dest.HireDate, src => GoogleDateTime.FromDateTimeOffset(src.HireDate))
                .Map(dest => dest.DepartmentHistories, src => src.DepartmentHistories!.Adapt<List<grpc_DepartmentHistoryCommand>>()); ;

            // To the UI, used to populate employee list page
            config.NewConfig<EmployeeListItem, grpc_EmployeeListItem>()
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? string.Empty : src.MiddleName)
                .Map(dest => dest.ManagerName, src => string.IsNullOrEmpty(src.ManagerName) ? string.Empty : src.ManagerName);

            config.NewConfig<grpc_EmployeeGenericCommand, UpdateEmployeeCommand>()
                .Map(dest => dest.Title, src => string.IsNullOrEmpty(src.Title) ? null : src.Title)
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? null : src.MiddleName)
                .Map(dest => dest.Suffix, src => string.IsNullOrEmpty(src.Suffix) ? null : src.Suffix)
                .Map(dest => dest.AddressLine2, src => string.IsNullOrEmpty(src.AddressLine2) ? null : src.AddressLine2)
                .Map(dest => dest.BirthDate, src => src.BirthDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.HireDate, src => src.HireDate.ToDateTime().ToLocalTime());

            // From the UI
            config.NewConfig<grpc_EmployeeGenericCommand, CreateEmployeeCommand>()
                .Map(dest => dest.Title, src => string.IsNullOrEmpty(src.Title) ? null : src.Title)
                .Map(dest => dest.MiddleName, src => string.IsNullOrEmpty(src.MiddleName) ? null : src.MiddleName)
                .Map(dest => dest.Suffix, src => string.IsNullOrEmpty(src.Suffix) ? null : src.Suffix)
                .Map(dest => dest.AddressLine2, src => string.IsNullOrEmpty(src.AddressLine2) ? null : src.AddressLine2)
                .Map(dest => dest.BirthDate, src => src.BirthDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.HireDate, src => src.HireDate.ToDateTime().ToLocalTime());

            // From the UI
            config.NewConfig<grpc_DepartmentHistoryCommand, AWC.Shared.Commands.HumanResources.DepartmentHistoryCommand>()
                .Map(dest => dest.BusinessEntityID, src => src.BusinessEntityId)
                .Map(dest => dest.DepartmentID, src => src.DepartmentId)
                .Map(dest => dest.ShiftID, src => src.ShiftId)
                .Map(dest => dest.StartDate, src => src.StartDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.EndDate, src => src.StartDate.ToDateTime().ToLocalTime());

            // From the UI
            config.NewConfig<grpc_PayHistoryCommand, AWC.Shared.Commands.HumanResources.PayHistoryCommand>()
                .Map(dest => dest.BusinessEntityID, src => src.BusinessEntityId)
                .Map(dest => dest.RateChangeDate, src => src.RateChangeDate.ToDateTime().ToLocalTime())
                .Map(dest => dest.Rate, src => (decimal)src.Rate)
                .Map(dest => dest.PayFrequency, src => src.PayFrequency);

            // Query to the UI
            config.NewConfig<AWC.Shared.Queries.HumanResources.DepartmentHistory, grpc_DepartmentHistory>()
                .Map(dest => dest.BusinessEntityId, src => src.BusinessEntityID)
                .Map(dest => dest.Department, src => src.Department)
                .Map(dest => dest.Shift, src => src.Shift)
                .Map(dest => dest.StartDate, src => GoogleDateTime.FromDateTimeOffset(src.StartDate))
                .Map(dest => dest.EndDate, src => src.EndDate != null ? GoogleDateTime.FromDateTimeOffset(src.EndDate.Value) : GoogleDateTime.FromDateTimeOffset(new DateTimeOffset()));

            // Query to the UI
            config.NewConfig<AWC.Shared.Queries.HumanResources.PayHistory, grpc_PayHistory>()
                .Map(dest => dest.BusinessEntityId, src => src.BusinessEntityID)
                .Map(dest => dest.RateChangeDate, src => GoogleDateTime.FromDateTimeOffset(src.RateChangeDate))
                .Map(dest => dest.Rate, src => (decimal)src.Rate)
                .Map(dest => dest.PayFrequency, src => src.PayFrequency);

            // Command to the UI
            config.NewConfig<AWC.Shared.Commands.HumanResources.DepartmentHistoryCommand, grpc_DepartmentHistoryCommand>()
                .Map(dest => dest.BusinessEntityId, src => src.BusinessEntityID)
                .Map(dest => dest.DepartmentId, src => src.DepartmentID)
                .Map(dest => dest.ShiftId, src => src.ShiftID)
                .Map(dest => dest.StartDate, src => GoogleDateTime.FromDateTimeOffset(src.StartDate))
                .Map(dest => dest.EndDate, src => src.EndDate != null ? GoogleDateTime.FromDateTimeOffset(src.EndDate.Value) : GoogleDateTime.FromDateTimeOffset(new DateTimeOffset()));

            // Command to the UI
            config.NewConfig<AWC.Shared.Commands.HumanResources.PayHistoryCommand, grpc_PayHistoryCommand>()
                .Map(dest => dest.BusinessEntityId, src => src.BusinessEntityID)
                .Map(dest => dest.RateChangeDate, src => GoogleDateTime.FromDateTimeOffset(src.RateChangeDate))
                .Map(dest => dest.Rate, src => (double)src.Rate)
                .Map(dest => dest.PayFrequency, src => src.PayFrequency);
        }
    }
}
