using FinanceTracker.Entities;
using FinanceTracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly FinanceDbContext _context;
        public BaseRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
            => await _context.AddAsync(entity);

        public void Delete(T entity)
        {
            entity.Delete();
            _context.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
           => await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();


    }
}
