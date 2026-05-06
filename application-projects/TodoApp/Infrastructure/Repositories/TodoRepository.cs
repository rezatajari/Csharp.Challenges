using Application.IRepositories;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public Task<TodoItem> AddAsync(TodoItem item)
        {
            throw new NotImplementedException();
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
