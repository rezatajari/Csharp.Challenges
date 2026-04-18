using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITodoRepository : IUnitOfWork
    {
        Task<TodoItem?> GetByIdAsync(int id);
        Task AddAsync(TodoItem todo);
    }
}
