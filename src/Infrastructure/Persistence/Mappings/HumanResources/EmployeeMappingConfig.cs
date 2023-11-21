#pragma warning disable S4830

using AWC.Core.Enums;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.SharedKernel.Utilities;
using Mapster;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public sealed class EmployeeMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // TypeAdapterConfig<TSource, TDestination> ((DateTime?)null)

            _ = config.NewConfig<AWC.Core.Entities.Shared.Address, AWC.Infrastructure.Persistence.DataModels.Person.Address>()
            .Map(dest => dest.AddressID, src => src.Id)
            .Map(dest => dest.AddressLine1, src => src.Location.AddressLine1)
            .Map(dest => dest.AddressLine2, src => src.Location.AddressLine2)
            .Map(dest => dest.City, src => src.Location.City)
            .Map(dest => dest.StateProvinceID, src => src.Location.StateProvinceID)
            .Map(dest => dest.PostalCode, src => src.Location.PostalCode);

            _ = config.NewConfig<AWC.Core.Entities.Shared.PersonPhone, AWC.Infrastructure.Persistence.DataModels.Person.PersonPhone>()
            .Map(dest => dest.BusinessEntityID, src => src.Id)
            .Map(dest => dest.PhoneNumber, src => src.Telephone.Value)
            .Map(dest => dest.PhoneNumberTypeID, src => (int)src.PhoneNumberType);

            _ = config.NewConfig<AWC.Core.Entities.Shared.PersonEmailAddress, AWC.Infrastructure.Persistence.DataModels.Person.EmailAddress>()
            .Map(dest => dest.BusinessEntityID, src => src.Id)
            .Map(dest => dest.EmailAddressID, src => src.EmailAddressID)
            .Map(dest => dest.MailAddress, src => src.EmailAddress.Value);

            _ = config.NewConfig<DepartmentHistory, EmployeeDepartmentHistory>()
            .Map(dest => dest.BusinessEntityID, src => src.Id)
            .Map(dest => dest.DepartmentID, src => src.DepartmentID)
            .Map(dest => dest.ShiftID, src => src.ShiftID)
            .Map(dest => dest.StartDate, src => src.StartDate.Value.ToDateTime(TimeOnly.MinValue))
            .Map(dest => dest.EndDate, src => new DateTime(((DateOnly)src.EndDate!.Value!).Year,
                                                           ((DateOnly)src.EndDate!.Value).Month,
                                                           ((DateOnly)src.EndDate!.Value).Day, 0, 0, 0, DateTimeKind.Local), srcCond => srcCond.EndDate != null)
            .Ignore(dest => dest.EndDate!);

            _ = config.NewConfig<PayHistory, EmployeePayHistory>()
            .Map(dest => dest.BusinessEntityID, src => src.Id)
            .Map(dest => dest.RateChangeDate, src => src.RateChangeDate.Value)
            .Map(dest => dest.Rate, src => src.PayRate.Value.Amount)
            .Map(dest => dest.PayFrequency, src => (byte)src.PayFrequency);

            _ = config.NewConfig<Employee, PersonDataModel>()
            .Map(dest => dest.BusinessEntityID, src => src.Id)
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

            _ = config.NewConfig<Employee, EmployeeDataModel>()
            .Map(dest => dest.BusinessEntityID, src => src.Id)
            .Map(dest => dest.ManagerID, src => src.ManagerID.Value)
            .Map(dest => dest.NationalIDNumber, src => src.NationalIDNumber.Value)
            .Map(dest => dest.BusinessEntityID, src => src.Id)
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
            .Map(dest => dest.DepartmentHistories, src => src.DepartmentHistories)
            .Map(dest => dest.PayHistories, src => src.PayHistories)
            .Ignore(dest => dest.DepartmentHistories)
            .Ignore(dest => dest.PayHistories);
        }
    }
}