using Application.IRepositories;
using Application.IServieces;
using Application.Shared;
using Application.Shared.DTOs;
using Domain.Entities;
using System;

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
                return Result<TodoItem>.Failure()
            return item;
        }

        public async Task<Result<TodoItem>> GetById(int Id, CancellationToken ct)
        {
            TodoItem? item = await todoRepo.GetAsync(Id, ct);
            if (item == null)
                throw new Exception("The item is not found");
            int databaseResponse = await todoRepo.SaveChangeAsync(ct);
            if (databaseResponse < 0)
                throw new Exception("Don't save in database");
            return item;
        }
    }
}
