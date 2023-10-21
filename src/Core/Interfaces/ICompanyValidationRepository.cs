using AWC.SharedKernel.Utilities;

namespace AWC.Core.Interfaces
{
    public interface ICompanyValidationRepository
    {
        Task<Result> ValidateCompanyNameIsUnique(int id, string companyName, bool asNoTracking = true);
    }
}