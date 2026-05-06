using Application.IRepositories;
using Application.IServieces;
using Application.Shared.DTOs;
using Domain.Entities;

namespace Application.Services
{
    public class TodoService(ITodoRepository todoRepo) : ITodoService
    {
        public Task<TodoItem> CreateTodoItem(CreateTodoForm requst)
        {
            throw new NotImplementedException();
        }
    }
}
