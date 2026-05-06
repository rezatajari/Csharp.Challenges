using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TodoRepository(TodoAppDb context) : ITodoRepository
    {
        public async Task AddAsync(TodoItem item, CancellationToken ct)
        {
            await context.AddAsync(item, ct);
            await context.SaveChangesAsync(ct);
        }

        public Task<TodoItem> DeleteAsync(int Id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoItem>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetAsync(int Id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangeAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> UpdateAsync(TodoItem item, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
