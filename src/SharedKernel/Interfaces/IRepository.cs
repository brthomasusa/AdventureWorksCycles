using AWC.SharedKernel.Utilities;

namespace AWC.SharedKernel.Interfaces
{
    public interface IRepository<T>
    {
        Task<Result<T>> GetByIdAsync(int id, bool asNoTracking = false);
        Task<Result<int>> InsertAsync(T entity);
        Task<Result<int>> Update(T entity);
        Task<Result<int>> Delete(int entityID);
    }
}
