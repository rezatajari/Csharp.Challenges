using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T>(FinanceDbContext context, ILogger<BaseRepository<T>> logger) 
        : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task AddAsync(T entity, CancellationToken ct)
        {
            logger.LogInformation("Preparing to add new {EntityName} to the database", typeof(T).Name);
            await _dbSet.AddAsync(entity, ct);
        }

        public void Delete(T entity, CancellationToken ct)
        {
            logger.LogWarning("Marking {EntityName} with Id {EntityId} as deleted", typeof(T).Name, entity.Id);
            entity.Delete();
            _dbSet.Update(entity);
        }

        public async Task<List<T>> GetAllAsync(
            CancellationToken ct,
            Expression<Func<T,bool>>? predict=null)
        {
            logger.LogInformation("Fetching all records for {EntityName}", typeof(T).Name);

            IQueryable<T> query = _dbSet;
            if (predict != null)
            {
                query = query.Where(predict);
            }
            return await query.ToListAsync(ct);
        }

        public async Task<T?> GetByIdAsync(int Id, CancellationToken ct)
        {
            logger.LogInformation("Fetching {EntityName} with Id {EntityId}", typeof(T).Name, Id);
            return await _dbSet.FindAsync(Id, ct);
        }

        public void Update(T entity)
        {
            logger.LogInformation("Updating {EntityName} with Id {EntityId}", typeof(T).Name, entity.Id);
            _dbSet.Update(entity);
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct)
        {
            try
            {
                var result = await context.SaveChangesAsync(ct);
                logger.LogInformation("Successfully persisted {Count} changes to the database", result);
                return result;
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Database update failure while saving changes for {EntityName}", typeof(T).Name);
                throw;
            }
        }
    }
}
