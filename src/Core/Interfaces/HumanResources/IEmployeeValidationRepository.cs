using AWC.SharedKernel.Utilities;

namespace AWC.Core.Interfaces.HumanResouces
{
    public interface IEmployeeValidationRepository
    {
        Task<Result> IsPersonNameIsUnique(int id, string fname, string lname, string? middleName, bool asNoTracking = true);
        Task<Result> IsNationalIdNumberIsUnique(int id, string nationalIdNumber, bool asNoTracking = true);
        Task<Result> IsEmployeeEmailIsUnique(int id, string emailAddres, bool asNoTracking = true);
        Task<Result> DoesEmployeeExist(int id, bool asNoTracking = true);
        Task<Result> DoesDepartmentExist(short id, bool asNoTracking = true);
        Task<Result> DoesShiftExist(byte id, bool asNoTracking = true);
        Task<Result> DoesManagerExist(int id, bool asNoTracking = true);
    }
}