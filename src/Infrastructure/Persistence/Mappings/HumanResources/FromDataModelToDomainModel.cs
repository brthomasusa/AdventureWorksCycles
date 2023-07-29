using AWC.Core.HumanResources;
using AWC.Core.Shared;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public static class FromDataModelToDomainModel
    {
        public static Result<Employee> MapToEmployeeDomainObject(this PersonDataModel person)
        {
            Result<Employee> createEmployee = Employee.Create
            (
                person!.BusinessEntityID,
                person!.PersonType!,
                person!.NameStyle ? NameStyleEnum.Eastern : NameStyleEnum.Western,
                person!.Title,
                person!.FirstName!,
                person!.LastName!,
                person!.MiddleName!,
                person!.Suffix,
                person!.Employee!.ManagerID,
                person!.Employee!.NationalIDNumber!,
                person!.Employee!.LoginID!,
                person!.Employee!.JobTitle!,
                DateOnly.FromDateTime(person!.Employee!.BirthDate),
                person!.Employee!.MaritalStatus!,
                person!.Employee!.Gender!,
                DateOnly.FromDateTime(person!.Employee!.HireDate),
                person!.Employee!.SalariedFlag,
                person!.Employee!.VacationHours,
                person!.Employee!.SickLeaveHours,
                person!.Employee!.CurrentFlag
            );

            if (createEmployee.IsSuccess)
            {
                // Add dept histories to employee from person data model
                person!.Employee!.DepartmentHistories.ToList().ForEach(dept =>
                    createEmployee.Value.AddDepartmentHistory(
                        dept.BusinessEntityID,
                        dept.DepartmentID,
                        dept.ShiftID,
                        DateOnly.FromDateTime(dept.StartDate),
                        dept.EndDate));

                // Add pay histories to employee from person data model
                person!.Employee!.PayHistories.ToList().ForEach(pay =>
                    createEmployee.Value.AddPayHistory(
                        pay.BusinessEntityID,
                        pay.RateChangeDate,
                        pay.Rate,
                        (PayFrequencyEnum)pay.PayFrequency
                    ));

                return createEmployee;
            }
            else
            {
                return Result<Employee>.Failure<Employee>(new Error("FromDataModelToDomainModel.MapToEmployeeDomainObject", createEmployee.Error.Message));
            }
        }
    }
}