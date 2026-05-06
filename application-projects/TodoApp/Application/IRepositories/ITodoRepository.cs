using Domain.Entities;

namespace Application.IRepositories
{
    public interface ITodoRepository
    {
        Task AddAsync(TodoItem item,CancellationToken ct);
        Task<TodoItem?> GetAsync(int Id,CancellationToken ct);
        Task<List<TodoItem>> GetAllAsync( CancellationToken ct);
        Task<TodoItem> UpdateAsync(TodoItem item, CancellationToken ct);
        Task<TodoItem> DeleteAsync(int Id, CancellationToken ct);
        Task<int> SaveChangeAsync( CancellationToken ct);
    }
}
