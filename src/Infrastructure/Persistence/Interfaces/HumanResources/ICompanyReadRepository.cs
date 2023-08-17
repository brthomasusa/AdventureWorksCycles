using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Interfaces.HumanResources
{
    public interface ICompanyReadRepository
    {
        Task<Result<CompanyDetails>> GetCompanyDetails(int companyId);
        Task<Result<CompanyGenericCommand>> GetCompanyCommand(int companyId);
        Task<Result<PagedList<DepartmentDetails>>> GetCompanyDepartments(PagingParameters pagingParameters);
        Task<Result<PagedList<DepartmentDetails>>> GetCompanyDepartmentsSearchByName(string deptName, PagingParameters pagingParameters);
        Task<Result<PagedList<DepartmentDetails>>> GetCompanyDepartmentsFiltered(StringSearchCriteria searchCriteria);
        Task<Result<PagedList<ShiftDetails>>> GetCompanyShifts(PagingParameters pagingParameters);
    }
}