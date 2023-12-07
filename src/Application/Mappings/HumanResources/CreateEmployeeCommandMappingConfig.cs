using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.SharedKernel.Utilities;
using AWC.Core.Enums;
using Mapster;

namespace AWC.Application.Mappings.HumanResources
{
    public sealed class CreateEmployeeCommandMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateEmployeeCommand, Result<Employee>>()
                .ConstructUsing(src =>
                    Employee.Create
                    (
                        new EmployeeID(src.BusinessEntityID),
                        "EM",
                        NameStyle.Western,
                        src.Title,
                        src.FirstName,
                        src.LastName,
                        src.MiddleName!,
                        src.Suffix,
                        new EmployeeID(src.ManagerID),
                        src.NationalIDNumber,
                        src.LoginID,
                        src.JobTitle,
                        DateOnly.FromDateTime(src.BirthDate),
                        src.MaritalStatus,
                        src.Gender,
                        DateOnly.FromDateTime(src.HireDate),
                        src.Salaried,
                        src.VacationHours,
                        src.SickLeaveHours,
                        src.Active
                    )
                );
        }
    }
}