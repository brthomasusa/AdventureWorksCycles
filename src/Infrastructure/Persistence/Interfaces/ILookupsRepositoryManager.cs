using AWC.Infrastructure.Persistence.Interfaces.Lookups;

namespace AWC.Infrastructure.Persistence.Interfaces
{
    public interface ILookupsRepositoryManager
    {
        ISharedLookupsRepository SharedLookupsRepository { get; }
        IHumanResourcesLookupsRepository HumanResourcesLookupsRepository { get; }
    }
}