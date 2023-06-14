using Ardalis.Specification;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;

namespace AWC.Infrastructure.Persistence.Specifications.HumanResources
{
    public sealed class ValidateEmployeeExistSpec : Specification<EmployeeDataModel>, ISingleResultSpecification
    {
        public ValidateEmployeeExistSpec(int employeeID)
            => Query.Where(employee => employee.BusinessEntityID == employeeID);
    }
}