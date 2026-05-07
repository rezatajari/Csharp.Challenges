using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TodoRepository(TodoAppDb context) : ITodoRepository
    {
        public async Task AddAsync(TodoItem item, CancellationToken ct)
        {
            await context.AddAsync(item, ct);
        }

        public Task<TodoItem> DeleteAsync(int Id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TodoItem>> GetAllAsync(CancellationToken ct)
        {
            return   await context.TodoItems.ToListAsync(ct);
        }

        public async Task<TodoItem?> GetAsync(int Id, CancellationToken ct)
        {
          return  await context.TodoItems.FirstOrDefaultAsync(t => t.Id == Id);
        }

        public async Task<int> SaveChangeAsync(CancellationToken ct)
        {
           return await context.SaveChangesAsync(ct);
        }

        public Task<TodoItem> UpdateAsync(TodoItem item, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
