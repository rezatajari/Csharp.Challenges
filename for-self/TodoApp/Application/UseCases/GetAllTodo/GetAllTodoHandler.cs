using Application.Common;
using Application.DTOs;
using Application.Interfaces;

namespace Application.UseCases.GetAllTodo
{
    public class GetAllTodoHandler
    {
        private readonly ITodoRepository _todoRepo;
        public GetAllTodoHandler(ITodoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public async Task<ReturnResponse<IEnumerable<ResponseTodoItemDto>>> Handle()
        {
            var todos = await _todoRepo.GetAllAsync();
            if (todos is null)
                return ReturnResponse<IEnumerable<ResponseTodoItemDto>>.Fail("No todo items found.");

            var responseDtos = todos.Select(todo => new ResponseTodoItemDto(todo.Id, todo.Title)).ToList();

            return ReturnResponse<IEnumerable<ResponseTodoItemDto>>.Ok(responseDtos);
        }
    }
}
