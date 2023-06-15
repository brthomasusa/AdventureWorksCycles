using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Interfaces.HumanResources
{
    public interface ICompanyReadRepository
    {
        Task<Result<GetCompanyDetailByIdResponse>> GetCompanyDetailsById(int companyId);
        Task<Result<GetCompanyCommandByIdResponse>> GetCompanyCommandById(int companyId);
        Task<Result<PagedList<GetCompanyDepartmentsResponse>>> GetCompanyDepartments(PagingParameters pagingParameters);
        Task<Result<PagedList<GetCompanyDepartmentsResponse>>> GetCompanyDepartmentsSearchByName(string deptName, PagingParameters pagingParameters);
        Task<Result<PagedList<GetCompanyShiftsResponse>>> GetCompanyShifts(PagingParameters pagingParameters);
    }
}