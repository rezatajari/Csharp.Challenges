using Application.Common.TodoApp.Application.Common.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.GetTodo
{
    public class GetTodosHandler
    {
        private readonly List<TodoItem> _todoItems=new List<TodoItem>();

        public ReturnResponse<TodoItem> Handle(Guid id)
        {
            var result=_todoItems.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return ReturnResponse<TodoItem>.Fail("Todo item not found");
            }

            return ReturnResponse<TodoItem>.Ok(result);
        }

    }
}
