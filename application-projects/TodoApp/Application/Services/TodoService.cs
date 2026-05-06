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
            return await SaveInDatabase(item, ct);
        }

        public async Task<Result<bool>> Delete(int Id, CancellationToken ct)
        {
            TodoItem? todoItem = await todoRepo.GetAsync(Id, ct);
            if (todoItem == null)
                return Result<bool>.Failure(ErrorMessages.NotFound);
            todoItem.Delete();
            return await SaveInDatabase(true, ct);
        }

        public async Task<Result<List<TodoItem>>> GetAll(CancellationToken ct)
        {
            List<TodoItem> todoItems = await todoRepo.GetAllAsync(ct);
            if (todoItems.Count == 0)
                return Result<List<TodoItem>>.Failure(ErrorMessages.NotFound);
            return Result<List<TodoItem>>.Success(todoItems);
        }

        public async Task<Result<TodoItem>> GetById(int Id, CancellationToken ct)
        {
            TodoItem? item = await todoRepo.GetAsync(Id, ct);
            if (item == null)
                   return Result<TodoItem>.Failure(ErrorMessages.NotFound);
            return Result<TodoItem>.Success(item);
        }

        public async Task<Result<bool>> Update(UpdateTodoRequest request, CancellationToken ct)
        {
            TodoItem? item = await todoRepo.GetAsync(request.Id, ct);
            if (item == null)
                return Result<bool>.Failure(ErrorMessages.NotFound);

            item.Update(request.NewTitle);
            return await SaveInDatabase(true, ct);
        }





        private async Task<Result<T>> SaveInDatabase<T>(T item,CancellationToken ct)
        {
            int databaseResponse = await todoRepo.SaveChangeAsync(ct);
            if (databaseResponse < 0)
                return Result<T>.Failure(ErrorMessages.DbError);
            return Result<T>.Success(item);
        }
    }
}
