using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        Task<T?> GetByIdAsync(int id, CancellationToken ct);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct);
        Task AddAsync(T entity, CancellationToken ct);
        void Update(T entity);
        void Delete(T entity, CancellationToken ct);
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
