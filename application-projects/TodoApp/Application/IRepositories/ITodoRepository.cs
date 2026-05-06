using Domain.Entities;

namespace Application.IRepositories
{
    public interface ITodoRepository
    {
        Task<TodoItem> AddAsync(TodoItem item);
        Task<TodoItem> GetAsync(int Id);
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem> UpdateAsync(TodoItem item);
        Task<TodoItem> DeleteAsync(int Id);
    }
}
