using AWC.Core.Interfaces.HumanResouces;

namespace AWC.Infrastructure.Persistence.Interfaces
{
    public interface IWriteRepositoryManager
    {
        IEmployeeWriteRepository EmployeeAggregateRepository { get; }
        ICompanyWriteRepository CompanyAggregateRepository { get; }
    }
}