using Application.Common.TodoApp.Application.Common.Responses;
using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.CreateTodo
{
    public class CreateTodoHandler
    {
        private static readonly List<TodoItem> _inMemoryStore = new();

        public ReturnResponse<TodoItem> Handle(CreateTodoDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return ReturnResponse<TodoItem>.Fail("Title cannot be empty.");

            var todo = new TodoItem(request.Title);

            _inMemoryStore.Add(todo);

            return ReturnResponse<TodoItem>.Ok(todo, "Todo item created successfully.");
        }
    }
}
