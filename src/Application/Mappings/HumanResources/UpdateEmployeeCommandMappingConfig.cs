using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.SharedKernel.Utilities;
using AWC.Core.Enums;
using Mapster;

namespace AWC.Application.Mappings.HumanResources
{
    public sealed class UpdateEmployeeCommandMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateEmployeeCommand, Result<Employee>>()
                .ConstructUsing(src =>
                    Employee.Create
                    (
                        new EmployeeID(src.BusinessEntityID),
                        "EM",
                        src.NameStyle == 0 ? NameStyle.Western : NameStyle.Eastern,
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