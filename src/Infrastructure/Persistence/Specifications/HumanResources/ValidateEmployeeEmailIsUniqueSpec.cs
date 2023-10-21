using Ardalis.Specification;
using AWC.Infrastructure.Persistence.DataModels.Person;

namespace AWC.Infrastructure.Persistence.Specifications.HumanResources
{
    public sealed class ValidateEmployeeEmailIsUniqueSpec : Specification<PersonDataModel>, ISingleResultSpecification
    {
        public ValidateEmployeeEmailIsUniqueSpec(string emailAddress)
            => Query
                    .Include(person => person.EmailAddresses!)
                    .Where(e => e.EmailAddresses.TrueForAll(addr => addr.MailAddress == emailAddress));
    }
}