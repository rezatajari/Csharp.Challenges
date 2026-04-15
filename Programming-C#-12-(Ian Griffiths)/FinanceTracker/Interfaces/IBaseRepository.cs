using FinanceTracker.Entities;

namespace FinanceTracker.Interfaces
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
