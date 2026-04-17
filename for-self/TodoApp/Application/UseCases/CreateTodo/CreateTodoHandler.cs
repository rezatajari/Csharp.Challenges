using Application.Common.TodoApp.Application.Common.Responses;
using Application.DTOs
using Domain.Entities;

namespace Application.UseCases.CreateTodo
{
    public class CreateTodoHandler
    {
        private readonly ITodoRepository _repo;
        public CreateTodoHandler(ITodoRepository repo)
        {
            _repo = repo;
        }

        public ReturnResponse<TodoItem> Handle(CreateTodoDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return ReturnResponse<TodoItem>.Fail("Title cannot be empty.");

            var todo = TodoItem.Create(request.Title);

            _repo.Add(todo);

            return ReturnResponse<TodoItem>.Ok(todo, "Todo item created successfully.");
        }
    }
}
