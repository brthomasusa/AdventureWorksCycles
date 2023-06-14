using Ardalis.Specification;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;

namespace AWC.Infrastructure.Persistence.Specifications.HumanResources
{
    public sealed class ValidateNationalIdNumberIsUniqueSpec : Specification<EmployeeDataModel>, ISingleResultSpecification
    {
        public ValidateNationalIdNumberIsUniqueSpec(string nationalIdNumber)
            => Query.Where(employee => employee.NationalIDNumber == nationalIdNumber);
    }
}