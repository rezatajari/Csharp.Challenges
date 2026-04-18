using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

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
            var result = await _todoRepo.SaveChangesAsync();
            if (result > 0)
                return ReturnResponse<TodoItem>.Ok(todo);

            return ReturnResponse<TodoItem>.Fail("Failed to create todo item.");
        }
    }
}
