using System;
using Ardalis.Specification;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;

namespace AWC.Infrastructure.Persistence.Specifications.HumanResources
{
    public sealed class ValidateDepartmentExistSpec : Specification<Department>, ISingleResultSpecification
    {
        public ValidateDepartmentExistSpec(short departmentID)
            => Query.Where(department => department.DepartmentID == departmentID);
    }
}