using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.Shared.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Interfaces.HumanResources
{
    public interface ICompanyReadRepository
    {
        Task<Result<CompanyDetailsForDisplay>> GetCompanyDetails(int companyId);
        Task<Result<CompanyDetailsForEdit>> GetCompanyCommand(int companyId);
        Task<Result<PagedList<GetCompanyDepartmentsResponse>>> GetCompanyDepartments(PagingParameters pagingParameters);
        Task<Result<PagedList<GetCompanyDepartmentsResponse>>> GetCompanyDepartmentsSearchByName(string deptName, PagingParameters pagingParameters);
        Task<Result<PagedList<GetCompanyShiftsResponse>>> GetCompanyShifts(PagingParameters pagingParameters);
    }
}