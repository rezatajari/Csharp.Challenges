using Application.Common.TodoApp.Application.Common.Responses;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
            var result=_repo.GetById(id);

            if (result == null)
                return ReturnResponse<TodoItem>.Fail("Todo item not found");

            return ReturnResponse<TodoItem>.Ok(result);
        }

    }
}
