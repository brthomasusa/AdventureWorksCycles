using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Mappings
{
    public abstract class ModelMapper<TSource, TDestination>
    {
        public abstract Result<TDestination> Map(TSource dataModel);
    }
}