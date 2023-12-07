using AWC.SharedKernel.Utilities;

namespace AWC.SharedKernel.Interfaces
{
    public abstract class ModelMapper<TSource, TDestination>
    {
        public abstract Result<TDestination> Map(TSource dataModel);
    }
}