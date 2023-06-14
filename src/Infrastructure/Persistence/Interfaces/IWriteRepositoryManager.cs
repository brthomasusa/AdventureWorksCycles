using AWC.Core.Interfaces;

namespace AWC.Infrastructure.Persistence.Interfaces
{
    public interface IWriteRepositoryManager
    {
        IEmployeeWriteRepository EmployeeAggregateRepository { get; }
        ICompanyWriteRepository CompanyAggregateRepository { get; }
    }
}