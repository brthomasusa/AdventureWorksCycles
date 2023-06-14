using AWC.Core.HumanResources;
using AWC.Core.Shared;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public static class FromDomainModelToDataModel
    {
        public static PersonDataModel MapToPersonDataModelForCreate(this Employee employee)
            => new()
            {
                PersonType = employee.PersonType,
                NameStyle = employee.NameStyle != NameStyleEnum.Western,
                Title = employee.Title,
                FirstName = employee.Name.FirstName,
                MiddleName = employee.Name.MiddleName,
                LastName = employee.Name.LastName,
                Suffix = employee.Suffix,
                EmailPromotion = (int)employee.EmailPromotions,
                Employee = new EmployeeDataModel()
                {
                    NationalIDNumber = employee.NationalIDNumber,
                    LoginID = employee.LoginID,
                    JobTitle = employee.JobTitle,
                    BirthDate = employee.BirthDate.Value.ToDateTime(new TimeOnly()),
                    MaritalStatus = employee.MaritalStatus,
                    Gender = employee.Gender,
                    HireDate = employee.HireDate.Value.ToDateTime(new TimeOnly()),
                    SalariedFlag = employee.IsSalaried,
                    VacationHours = employee.VacationHours,
                    SickLeaveHours = employee.SickLeaveHours,
                    CurrentFlag = employee.IsActive
                }
            };

        public static void MapToPersonDataModelForUpdate(this Employee employee, ref PersonDataModel person)
        {
            person.PersonType = employee.PersonType;
            person.NameStyle = employee.NameStyle != NameStyleEnum.Western;
            person.Title = employee.Title;
            person.FirstName = employee.Name.FirstName;
            person.MiddleName = employee.Name.MiddleName!;
            person.LastName = employee.Name.LastName;
            person.Suffix = employee.Suffix;
            person.EmailPromotion = (int)employee.EmailPromotions;

            person.Employee!.NationalIDNumber = employee.NationalIDNumber;
            person.Employee!.LoginID = employee.LoginID;
            person.Employee!.JobTitle = employee.JobTitle;
            person.Employee!.BirthDate = employee.BirthDate.Value.ToDateTime(new TimeOnly());
            person.Employee!.MaritalStatus = employee.MaritalStatus;
            person.Employee!.Gender = employee.Gender;
            person.Employee!.HireDate = employee.HireDate.Value.ToDateTime(new TimeOnly());
            person.Employee!.SalariedFlag = employee.IsSalaried;
            person.Employee!.VacationHours = employee.VacationHours;
            person.Employee!.SickLeaveHours = employee.SickLeaveHours;
            person.Employee!.CurrentFlag = employee.IsActive;
        }

        public static void MapDataModelAddressToDomainAddress(this BusinessEntityAddress businessEntityAddress, ref Employee employee)
            => employee.AddAddress(businessEntityAddress.AddressID,
                                   businessEntityAddress.BusinessEntityID,
                                   (AddressTypeEnum)businessEntityAddress.AddressTypeID,
                                   businessEntityAddress.Address!.AddressLine1!,
                                   businessEntityAddress.Address.AddressLine2,
                                   businessEntityAddress.Address!.City!,
                                   businessEntityAddress.Address.StateProvinceID,
                                   businessEntityAddress.Address!.PostalCode!);
    }
}