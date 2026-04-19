using Domain.Entities;
using FinanceTracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Data.Repositories
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

        public async Task AddAsync(T entity)
            => await _dbSet.AddAsync(entity);

        public void Delete(T entity)
        {
            entity.Delete();
            _dbSet.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
           => await _dbSet.FindAsync(id);

        public void Update(T entity)
           => _dbSet.Update(entity);

        public async Task<int> SaveChangesAsync()
            => await  _context.SaveChangesAsync();
    }
}
