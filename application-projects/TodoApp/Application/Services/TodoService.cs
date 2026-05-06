using Application.IRepositories;
using Application.IServieces;
using Application.Shared.DTOs;
using Domain.Entities;

namespace Application.Services
{
    public class TodoService(ITodoRepository todoRepo) : ITodoService
    {
        public async Task<TodoItem> CreateTodoItem(CreateTodoForm requst,CancellationToken ct)
        {
            TodoItem item = TodoItem.Create(requst.Title);
            await todoRepo.AddAsync(item, ct);
            int databaseResponse =await todoRepo.SaveChangeAsync(ct);
            if (databaseResponse < 0)
                throw new Exception("Don't save in satabase");
            return item;
        }

        public Task<TodoItem> GetById(int Id, CancellationToken ct)
        {
        }
    }
}
