using Application.Common;
using Application.Interfaces;

namespace Application.UseCases.DeleteTodo
{
    public class DeleteTodoHandler
    {
        private readonly ITodoRepository _todoRepo;
        public DeleteTodoHandler(ITodoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public async Task<ReturnResponse<bool>> Handle(int id)
        {
            var todo = await _todoRepo.GetByIdAsync(id);
            if (todo is null)
                return ReturnResponse<bool>.Fail("Todo item not found.");

            todo.Delete();
            var result = await _todoRepo.SaveChangesAsync();

            return (result > 0)
                ? ReturnResponse<bool>.Ok(true, "Todo item deleted successfully.")
                : ReturnResponse<bool>.Fail("Failed to delete the todo item.");
        }
    }
}
