using AWC.Core.Interfaces;

namespace AWC.Infrastructure.Persistence.Interfaces
{
    public interface IValidationRepositoryManager
    {
        IEmployeeValidationRepository EmployeeAggregateRepository { get; }
        ICompanyValidationRepository CompanyAggregateRepository { get; }
    }
}