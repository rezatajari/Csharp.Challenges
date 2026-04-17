using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITodoRepository: IUnitOfWork
    {
        TodoItem? GetByIdAsync(Guid id);
        Task AddAsync(TodoItem todo);
        IEnumerable<TodoItem> GetAllAsync();
    }
}
