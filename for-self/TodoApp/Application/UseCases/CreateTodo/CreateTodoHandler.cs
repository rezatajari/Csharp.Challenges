using Application.Common.TodoApp.Application.Common.Responses;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.UseCases.CreateTodo
{
    public class CreateTodoHandler
    {
        private readonly ITodoRepository _todoRepo;
        public CreateTodoHandler(ITodoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public async Task<ReturnResponse<TodoItem>> Handle(CreateTodoDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return ReturnResponse<TodoItem>.Fail("Title cannot be empty.");

            var todo = TodoItem.Create(request.Title);

            await _todoRepo.AddAsync(todo);
            await _todoRepo.SaveChangesAsync();

            return ReturnResponse<TodoItem>.Ok(todo, "Todo item created successfully.");
        }
    }
}
