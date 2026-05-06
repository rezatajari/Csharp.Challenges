using Application.Shared;
using Application.Shared.DTOs;
using Domain.Entities;

namespace Application.IServieces
{
    public interface ITodoService
    {
        Task<Result<TodoItem>> CreateTodoItem(CreateTodoForm requst,CancellationToken ct);
        Task<Result<TodoItem>> GetById(int Id,CancellationToken ct);
    }
}
