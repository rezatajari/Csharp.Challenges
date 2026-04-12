using Application.Common.TodoApp.Application.Common.Responses;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.CreateTodo
{
    public class CreateTodoHandler
    {
        private readonly ITodoRepository _repo;
        public CreateTodoHandler(ITodoRepository repo)
        {
            _repo = repo;
        }

        public ReturnResponse<TodoItem> Handle(CreateTodoDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return ReturnResponse<TodoItem>.Fail("Title cannot be empty.");

            var todo = new TodoItem(request.Title);

            _repo.Add(todo);

            return ReturnResponse<TodoItem>.Ok(todo, "Todo item created successfully.");
        }
    }
}
