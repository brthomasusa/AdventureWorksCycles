using Ardalis.Specification;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;

namespace AWC.Infrastructure.Persistence.Specifications.HumanResources
{
    public sealed class CompanyByIdSpec : Specification<Company>, ISingleResultSpecification
    {
        public CompanyByIdSpec(int companyID)
        {
            Query.Where(company => company.CompanyID == companyID);
        }
    }
}