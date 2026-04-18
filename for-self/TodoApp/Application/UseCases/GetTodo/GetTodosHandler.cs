using Application.Common;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases.GetTodo
{
    public class GetTodosHandler
    {
        private readonly ITodoRepository _repo;

        public GetTodosHandler(ITodoRepository repo)
        {
            _repo = repo;
        }

        public ReturnResponse<TodoItem> Handle(Guid id)
        {
            var result=_repo.GetByIdAsync(id);

            if (result == null)
                return ReturnResponse<TodoItem>.Fail("Todo item not found");

            return ReturnResponse<TodoItem>.Ok(result);
        }

    }
}
