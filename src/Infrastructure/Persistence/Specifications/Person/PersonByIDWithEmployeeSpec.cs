using Ardalis.Specification;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;

namespace AWC.Infrastructure.Persistence.Specifications.Person
{
    public sealed class PersonByIDWithEmployeeSpec : Specification<PersonDataModel>, ISingleResultSpecification
    {
        public PersonByIDWithEmployeeSpec(int businessEntityID)
        {
            Query.Where(person => person.BusinessEntityID == businessEntityID)
                 .Include(person => person.Employee!)
                 .Include(person => person.Employee!.DepartmentHistories)
                 .Include(person => person.Employee!.PayHistories)
                 .Include(person => person.EmailAddresses!)
                 .Include(person => person.Telephones!)
                 .Include(person => person.BusinessEntityAddresses!)
                    .ThenInclude(addr => addr.Address!);
        }
    }
}
