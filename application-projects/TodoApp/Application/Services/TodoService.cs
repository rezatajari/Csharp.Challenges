using Application.IRepositories;
using Application.IServieces;
using Application.Shared;
using Application.Shared.DTOs;
using Domain.Entities;

namespace Application.Services
{
    public class TodoService(ITodoRepository todoRepo) : ITodoService
    {
        public async Task<Result<TodoItem>> CreateTodoItem(CreateTodoForm requst, CancellationToken ct)
        {
            TodoItem item = TodoItem.Create(requst.Title);
            await todoRepo.AddAsync(item, ct);
            int databaseResponse = await todoRepo.SaveChangeAsync(ct);
            if (databaseResponse < 0)
                return Result<TodoItem>.Failure(ErrorMessages.DbError);
            return Result<TodoItem>.Success(item);
        }

        public async Task<Result<TodoItem>> GetById(int Id, CancellationToken ct)
        {
            TodoItem? item = await todoRepo.GetAsync(Id, ct);
            if (item == null)
                   return Result<TodoItem>.Failure(ErrorMessages.NotFound);
            int databaseResponse = await todoRepo.SaveChangeAsync(ct);
            if (databaseResponse < 0)
                return Result<TodoItem>.Failure(ErrorMessages.DbError);
            return Result<TodoItem>.Success(item);
        }
    }
}
