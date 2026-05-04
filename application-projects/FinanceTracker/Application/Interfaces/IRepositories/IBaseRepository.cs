using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        Task<T?> GetByIdAsync(int id, CancellationToken ct);
        Task<List<T>> GetAllAsync(CancellationToken ct, Expression<Func<T, bool>>? predict = null);
        Task AddAsync(T entity, CancellationToken ct);
        void Update(T entity);
        void Delete(T entity, CancellationToken ct);
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
