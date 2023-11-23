#pragma warning disable S4830

using AWC.Core.Enums;
using AWC.Core.Entities.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using Mapster;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public sealed class EmployeeMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // TypeAdapterConfig<TSource, TDestination> ((DateTime?)null)

            // Domain model to data model
            _ = config.NewConfig<DepartmentHistory, EmployeeDepartmentHistory>()
            .Map(dest => dest.BusinessEntityID, src => src.Id.Value)
            .Map(dest => dest.DepartmentID, src => src.DepartmentID.Value)
            .Map(dest => dest.ShiftID, src => src.ShiftID.Value)
            .Map(dest => dest.StartDate, src => src.StartDate.Value.ToDateTime(TimeOnly.MinValue))
            .Map(dest => dest.EndDate, src => new DateTime(((DateOnly)src.EndDate!.Value!).Year,
                                                           ((DateOnly)src.EndDate!.Value).Month,
                                                           ((DateOnly)src.EndDate!.Value).Day, 0, 0, 0, DateTimeKind.Local), srcCond => srcCond.EndDate != null)
            .Ignore(dest => dest.EndDate!);

            // Domain model to data model
            _ = config.NewConfig<PayHistory, EmployeePayHistory>()
            .Map(dest => dest.BusinessEntityID, src => src.Id.Value)
            .Map(dest => dest.RateChangeDate, src => src.RateChangeDate.Value)
            .Map(dest => dest.Rate, src => src.PayRate.Value.Amount)
            .Map(dest => dest.PayFrequency, src => (byte)src.PayFrequency);

            // Domain model to data model
            _ = config.NewConfig<Employee, PersonDataModel>()
            .Map(dest => dest.BusinessEntityID, src => src.Id.Value)
            .Map(dest => dest.PersonType, src => src.PersonType.Value)
            .Map(dest => dest.NameStyle, src => src.NameStyle != NameStyle.Western)
            .Map(dest => dest.Title, src => src.Title.Value)
            .Map(dest => dest.FirstName, src => src.Name.FirstName)
            .Map(dest => dest.MiddleName, src => src.Name.MiddleName)
            .Map(dest => dest.LastName, src => src.Name.LastName)
            .Map(dest => dest.Suffix, src => src.Suffix.Value)
            .Map(dest => dest.EmailPromotion, src => (int)src.EmailPromotions)
            .Ignore(dest => dest.Employee!)
            .Ignore(dest => dest.EmailAddresses)
            .Ignore(dest => dest.BusinessEntityAddresses)
            .Ignore(dest => dest.Telephones);

            // Domain model to data model
            _ = config.NewConfig<Employee, EmployeeDataModel>()
            .Map(dest => dest.BusinessEntityID, src => src.Id.Value)
            .Map(dest => dest.ManagerID, src => src.ManagerID.Value)
            .Map(dest => dest.NationalIDNumber, src => src.NationalIDNumber.Value)
            .Map(dest => dest.BusinessEntityID, src => src.Id.Value)
            .Map(dest => dest.LoginID, src => src.LoginID.Value)
            .Map(dest => dest.JobTitle, src => src.JobTitle.Value)
            .Map(dest => dest.BirthDate, src => ((DateOnly)src.BirthDate).ToDateTime(TimeOnly.MinValue))
            .Map(dest => dest.MaritalStatus, src => src.MaritalStatus.Value)
            .Map(dest => dest.Gender, src => src.Gender.Value)
            .Map(dest => dest.HireDate, src => ((DateOnly)src.HireDate).ToDateTime(TimeOnly.MinValue))
            .Map(dest => dest.SalariedFlag, src => src.IsSalaried)
            .Map(dest => dest.VacationHours, src => src.VacationHours)
            .Map(dest => dest.SickLeaveHours, src => src.SickLeaveHours)
            .Map(dest => dest.CurrentFlag, src => src.IsActive)
            .Ignore(dest => dest.DepartmentHistories)
            .Ignore(dest => dest.PayHistories);
        }
    }
}