using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TodoRepository(TodoAppDb context) : ITodoRepository
    {
        public Task<TodoItem> AddAsync(TodoItem item)
        {
        }

        public Task<TodoItem> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> UpdateAsync(TodoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
