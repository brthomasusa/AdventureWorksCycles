using Ardalis.Specification;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using Microsoft.EntityFrameworkCore;

namespace AWC.Infrastructure.Persistence.Specifications.HumanResources
{
    public sealed class ValidateCompanyNameIsUniqueSpec : Specification<Company>, ISingleResultSpecification
    {
        private const string CI = "SQL_Latin1_General_CP1_CI_AS";

        public ValidateCompanyNameIsUniqueSpec(string companyName)
            => Query.Where(company => EF.Functions.Collate(company.CompanyName!, CI) == companyName);
    }
}