using Application.Common;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.CompleteTodo
{
    public class CompleteTodoHandler
    {
        private readonly ITodoRepository _todoRepo;
        public CompleteTodoHandler(ITodoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public async Task<ReturnResponse<bool>> Handle(int id)
        {
            var todo = await _todoRepo.GetByIdAsync(id);
            if (todo == null)
                return ReturnResponse<bool>.Fail("Todo item not found.");

            todo.Complete();
            var result = await _todoRepo.SaveChangesAsync();

            return (result > 0)
                ? ReturnResponse<bool>.Ok(true)
                : ReturnResponse<bool>.Fail("Failed to complete the todo item.");
        }
    }
}
