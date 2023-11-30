using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;

namespace AWC.UnitTest.Shared.Data.MockRepositories
{
    public class GetCompanyMockData
    {
        public static Result<Company> GetCompanyWithDepartmentsAndShifts()
        {
            Result<Company> company = CampanyTestData.CompanyResultWithValidData();

            CampanyTestData.GetDepartmentDataModels().ForEach(dept =>
                company.Value.AddDepartment(new DepartmentID(dept.DepartmentID), dept.Name!, dept.GroupName!)
            );

            CampanyTestData.GetShiftDataModels().ForEach(shift => company.Value.AddShift
            (
                new ShiftID(shift.ShiftID),
                shift.Name!,
                shift.StartTime.Hours,
                shift.StartTime.Minutes,
                shift.EndTime.Hours,
                shift.EndTime.Minutes
            ));

            return company;
        }
    }
}