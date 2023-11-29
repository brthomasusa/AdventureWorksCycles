using AWC.Infrastructure.Persistence.DataModels.HumanResources;

namespace AWC.UnitTest.Shared.Data.MockRepositories
{
    public class GetDepartmentsMockData
    {
        public static List<Department> GetDepartments()
            => new()
            {
                new()
                {
                    DepartmentID = 1,
                    Name = "Admin",
                    GroupName = "Admin Group",
                },
                new()
                {
                    DepartmentID = 2,
                    Name = "Sales",
                    GroupName = "Sales and Marketing",
                },
                new()
                {
                    DepartmentID = 3,
                    Name = "Engineering",
                    GroupName = "Engineering",
                },
                new()
                {
                    DepartmentID = 4,
                    Name = "Quality Assurance",
                    GroupName = "QA Group",
                }
            };
    }
}