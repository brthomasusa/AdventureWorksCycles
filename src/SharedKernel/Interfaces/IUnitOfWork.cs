
namespace AWC.SharedKernel.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
