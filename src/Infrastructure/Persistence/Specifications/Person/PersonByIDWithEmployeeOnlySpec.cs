using Ardalis.Specification;
using AWC.Infrastructure.Persistence.DataModels.Person;

namespace AWC.Infrastructure.Persistence.Specifications.Person
{
    public class PersonByIDWithEmployeeOnlySpec : Specification<PersonDataModel>, ISingleResultSpecification
    {
        public PersonByIDWithEmployeeOnlySpec(int businessEntityID)
        {
            Query.Where(person => person.BusinessEntityID == businessEntityID)
                 .Include(person => person.Employee!);
        }
    }
}