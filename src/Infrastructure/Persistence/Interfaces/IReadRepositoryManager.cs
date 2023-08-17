using AWC.Infrastructure.Persistence.Interfaces.HumanResources;

namespace AWC.Infrastructure.Persistence.Interfaces
{
    public interface IReadRepositoryManager
    {
        IEmployeeReadRepository EmployeeReadRepository { get; }
        ICompanyReadRepository CompanyReadRepository { get; }
    }
}