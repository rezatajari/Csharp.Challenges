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

        public async Task<ReturnResponse<ResponseTodoItemDto>> Handle(CreateTodoDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return ReturnResponse<ResponseTodoItemDto>.Fail("Title cannot be empty.");

            var todo = TodoItem.Create(request.Title);

            await _todoRepo.AddAsync(todo);
            var result = await _todoRepo.SaveChangesAsync();

            ResponseTodoItemDto responseDto = new ResponseTodoItemDto( todo.Id,todo.Title);

            return (result > 0)
                ? ReturnResponse<ResponseTodoItemDto>.Ok(responseDto)
                : ReturnResponse<ResponseTodoItemDto>.Fail("Failed to create todo item.");
        }
    }
}
