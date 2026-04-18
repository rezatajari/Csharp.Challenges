using Application.Common;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

        }
    }
}
