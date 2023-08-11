using Ardalis.Specification;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;

namespace AWC.Infrastructure.Persistence.Specifications.HumanResources
{
    public sealed class ValidateEmployeeManagerExistSpec : Specification<EmployeeManager>, ISingleResultSpecification
    {
        public ValidateEmployeeManagerExistSpec(int managerID)
            => Query.Where(manager => manager.BusinessEntityID == managerID);
    }
}