using Application.Common;
using Application.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.UseCases.GetTodo
{
    public class GetTodosHandler
    {
        private readonly ITodoRepository _repo;

        public GetTodosHandler(ITodoRepository repo)
        {
            _repo = repo;
        }

        public async Task<ReturnResponse<TodoItem>> Handle(int id)
        {
            var result=await _repo.GetByIdAsync(id);

             return (result == null)
                ? ReturnResponse<TodoItem>.Fail("Todo item not found")
                : ReturnResponse<TodoItem>.Ok(result);
        }

    }
}
