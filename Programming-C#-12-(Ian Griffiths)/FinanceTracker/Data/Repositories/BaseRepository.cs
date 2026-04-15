using FinanceTracker.Entities;
using FinanceTracker.Interfaces;

namespace FinanceTracker.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly FinanceDbContext _context;
        public BaseRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity) => await _context.AddAsync(entity);

        public void Delete(T entity)
        {
            entity.Delete();
            _context.Update(entity);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();


    }
}
