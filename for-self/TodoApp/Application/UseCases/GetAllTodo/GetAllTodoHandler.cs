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

        public async Task<IEnumerable<ResponseTodoItemDto>> Handle()
        {
            var todos=await _todoRepo.
        }
    }
}
