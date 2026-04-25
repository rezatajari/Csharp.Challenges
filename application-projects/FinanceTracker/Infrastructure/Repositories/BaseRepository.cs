using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly FinanceDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(FinanceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken ct)
            => await _dbSet.AddAsync(entity,ct);

        public void Delete(T entity, CancellationToken ct)
        {
            entity.Delete();
            _dbSet.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct)
            => await _dbSet.ToListAsync(ct);

        public async Task<T?> GetByIdAsync(int id, CancellationToken ct)
           => await _dbSet.FindAsync(id,ct);

        public void Update(T entity)
           => _dbSet.Update(entity);

        public async Task<int> SaveChangesAsync(CancellationToken ct)
            => await  _context.SaveChangesAsync(ct);
    }
}
