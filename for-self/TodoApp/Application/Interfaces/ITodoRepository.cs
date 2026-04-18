using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITodoRepository : IUnitOfWork
    {
        TodoItem? GetByIdAsync(int id);
        Task AddAsync(TodoItem todo);
        Task<IEnumerable<TodoItem>> GetAllAsync();
    }
}
