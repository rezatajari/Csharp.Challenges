using Application.Shared;
using Application.Shared.DTOs;
using Domain.Entities;

namespace Application.IServieces
{
    public interface ITodoService
    {
        Task<Result<TodoItem>> CreateTodoItem(CreateTodoForm requst,CancellationToken ct);
        Task<Result<TodoItem>> GetById(int Id,CancellationToken ct);
        Task<Result<List<TodoItem>>> GetAll(CancellationToken ct);

        Task<Result<bool>> Delete(int Id,CancellationToken ct);
        Task<Result<bool>> Update(UpdateTodoRequest request,CancellationToken ct);
    }
}
