using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Interfaces.HumanResources
{
    public interface ICompanyReadRepository
    {
        Task<Result<CompanyDetailsForDisplay>> GetCompanyDetails(int companyId);
        Task<Result<CompanyDetailsForEdit>> GetCompanyCommand(int companyId);
        Task<Result<PagedList<DepartmentDetails>>> GetCompanyDepartments(PagingParameters pagingParameters);
        Task<Result<PagedList<DepartmentDetails>>> GetCompanyDepartmentsSearchByName(string deptName, PagingParameters pagingParameters);
        Task<Result<PagedList<ShiftDetails>>> GetCompanyShifts(PagingParameters pagingParameters);
    }
}