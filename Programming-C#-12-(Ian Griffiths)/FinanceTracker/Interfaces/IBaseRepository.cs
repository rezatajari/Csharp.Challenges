using FinanceTracker.Entities;

namespace FinanceTracker.Interfaces
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        void AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}
