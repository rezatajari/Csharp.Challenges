using Application.Shared.DTOs;
using Domain.Entities;

namespace Application.IServieces
{
    public interface ITodoService
    {
        Task<TodoItem> CreateTodoItem(CreateTodoForm requst,CancellationToken ct);
        Task<TodoItem> GetById(int Id,CancellationToken ct);
    }
}
