using AWC.Core.Interfaces.HumanResouces;

namespace AWC.Infrastructure.Persistence.Interfaces
{
    public interface IValidationRepositoryManager
    {
        IEmployeeValidationRepository EmployeeAggregateRepository { get; }
        ICompanyValidationRepository CompanyAggregateRepository { get; }
    }
}