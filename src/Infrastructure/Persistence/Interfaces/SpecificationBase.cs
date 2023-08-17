using System.Linq.Expressions;

namespace AWC.Infrastructure.Persistence.Interfaces
{
    public abstract class SpecificationBase<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }
    }
}