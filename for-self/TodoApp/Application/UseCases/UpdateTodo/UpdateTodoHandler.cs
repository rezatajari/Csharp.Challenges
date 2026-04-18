using Application.Common;
using Application.DTOs;
using Application.Interfaces;

namespace Application.UseCases.UpdateTodo
{
    public class UpdateTodoHandler
    {
        private readonly ITodoRepository _todoRepo;

        public UpdateTodoHandler(ITodoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public async Task<ReturnResponse<bool>> Handle(UpdateTodoDto request)
        {
            var todo= await _todoRepo.GetByIdAsync(request.id);
            if (todo == null)
                return ReturnResponse<bool>.Fail("Todo item not found.");

            todo.Update(request.title);
            var result =await _todoRepo.SaveChangesAsync();

            return (result>0)
                ? ReturnResponse<bool>.Ok(true)
                : ReturnResponse<bool>.Fail("Failed to update the todo item.");
        }
    }
}
