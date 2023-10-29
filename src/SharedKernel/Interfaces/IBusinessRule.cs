using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.SharedKernel.Interfaces
{
    public interface IBusinessRule<T>
    {
        void SetNext(IBusinessRule<T> next);

        Task<ValidationResult> Validate(T request);
    }
}