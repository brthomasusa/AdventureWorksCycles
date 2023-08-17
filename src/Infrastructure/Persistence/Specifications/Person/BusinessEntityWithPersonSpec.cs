using Ardalis.Specification;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;

namespace AWC.Infrastructure.Persistence.Specifications.Person
{
    public sealed class BusinessEntityWithPersonSpec : Specification<BusinessEntity>, ISingleResultSpecification
    {
        public BusinessEntityWithPersonSpec(int businessEntityID)
            => Query.Where(entity => entity.BusinessEntityID == businessEntityID)
                    .Include(entity => entity.PersonModel)
                    .Include(entity => entity.PersonModel!.Employee!)
                    .Include(entity => entity.PersonModel!.Employee!.DepartmentHistories)
                    .Include(entity => entity.PersonModel!.Employee!.PayHistories)
                    .Include(entity => entity.PersonModel!.EmailAddresses!)
                    .Include(entity => entity.PersonModel!.Telephones!)
                    .Include(entity => entity.PersonModel!.Password)
                    .Include(entity => entity.PersonModel!.BusinessEntityAddresses!);
    }
}