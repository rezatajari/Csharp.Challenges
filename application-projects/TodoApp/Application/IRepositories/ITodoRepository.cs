using Domain.Entities;

namespace Application.IRepositories
{
    public interface ITodoRepository
    {
        Task<TodoItem> AddAsync(TodoItem item,CancellationToken ct);
        Task<TodoItem> GetAsync(int Id,CancellationToken ct);
        Task<List<TodoItem>> GetAllAsync( CancellationToken ct);
        Task<TodoItem> UpdateAsync(TodoItem item, CancellationToken ct);
        Task<TodoItem> DeleteAsync(int Id, CancellationToken ct);
        Task SaveChangeAsync( CancellationToken ct);
    }
}
