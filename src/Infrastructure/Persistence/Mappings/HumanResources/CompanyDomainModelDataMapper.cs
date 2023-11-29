using CompanyDomainModel = AWC.Core.Entities.HumanResources.Company;
using CompanyDataModel = AWC.Infrastructure.Persistence.DataModels.HumanResources.Company;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public static class CompanyDomainModelDataMapper
    {
        public static Result<CompanyDomainModel> MapFromDataModel
        (
            CompanyDataModel dataModel,
            List<Infrastructure.Persistence.DataModels.HumanResources.Department> departments,
            List<AWC.Infrastructure.Persistence.DataModels.HumanResources.Shift> shifts
        )
        {
            Result<CompanyDomainModel> result = CompanyDomainModel.Create(
                new CompanyID(dataModel.CompanyID),
                dataModel.CompanyName!,
                dataModel.LegalName!,
                dataModel.EIN!,
                dataModel.WebsiteUrl!,
                dataModel.MailAddressLine1!,
                dataModel.DeliveryAddressLine2,
                dataModel.MailCity!,
                dataModel.MailStateProvinceID,
                dataModel.MailPostalCode!,
                dataModel.DeliveryAddressLine1!,
                dataModel.DeliveryAddressLine2,
                dataModel.DeliveryCity!,
                dataModel.DeliveryStateProvinceID,
                dataModel.DeliveryPostalCode!,
                dataModel.Telephone!,
                dataModel.Fax!
            );

            if (result.IsFailure)
                return Result<CompanyDomainModel>.Failure<CompanyDomainModel>(new Error("CompanyDomainModelDataMapper.MapFromDataModel", result.Error.Message));

            CompanyDomainModel company = result.Value;

            try
            {
                if (departments.Any())
                {
                    departments.ForEach(dept => company.AddDepartment(new DepartmentID(dept.DepartmentID), dept.Name!, dept.GroupName!));
                }

                if (shifts.Any())
                {
                    shifts.ForEach(shift => company.AddShift(
                        new ShiftID(shift.ShiftID), shift.Name!, shift.StartTime.Hours, shift.StartTime.Minutes, shift.EndTime.Hours, shift.EndTime.Minutes
                    ));
                }

                return company;
            }
            catch (Exception ex)
            {
                return Result<CompanyDomainModel>.Failure<CompanyDomainModel>(new Error("CompanyDomainModelDataMapper.MapFromDataModel", Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}