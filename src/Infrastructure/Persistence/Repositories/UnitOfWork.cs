using AWC.SharedKernel.Interfaces;

namespace AWC.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _isDisposed;
        private readonly AwcContext _dbContext;

        public UnitOfWork(AwcContext ctx) => _dbContext = ctx;

        ~UnitOfWork() => Dispose(false);

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
            => await _dbContext.SaveChangesAsync(cancellationToken);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
                _dbContext.Dispose();

            _isDisposed = true;
        }
    }
}