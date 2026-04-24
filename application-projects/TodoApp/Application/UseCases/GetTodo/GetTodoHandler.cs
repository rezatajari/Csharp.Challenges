using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.UseCases.GetTodo
{
    public class GetTodoHandler
    {
        private readonly ITodoRepository _repo;

        public GetTodoHandler(ITodoRepository repo)
        {
            _repo = repo;
        }

        public async Task<ReturnResponse<ResponseTodoItemDto>> Handle(int id)
        {
            var todo =await _repo.GetByIdAsync(id);

            return (todo == null)
                ? ReturnResponse<ResponseTodoItemDto>.Fail("Todo item not found")
                : ReturnResponse<ResponseTodoItemDto>.Ok(new ResponseTodoItemDto(todo.Id, todo.Title));
        }

    }
}
