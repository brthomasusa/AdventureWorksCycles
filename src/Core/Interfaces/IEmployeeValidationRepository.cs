using AWC.Core.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.Interfaces
{
    public interface IEmployeeValidationRepository
    {
        Task<Result> ValidatePersonNameIsUnique(int id, string fname, string lname, string? middleName, bool asNoTracking = true);
        Task<Result> ValidateNationalIdNumberIsUnique(int id, string nationalIdNumber, bool asNoTracking = true);
        Task<Result> ValidateEmployeeEmailIsUnique(int id, string emailAddres, bool asNoTracking = true);
        Task<Result> ValidateEmployeeExist(int id, bool asNoTracking = true);
    }
}