using Application.Shared.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServieces
{
    public interface ITodoService
    {
        Task<TodoItem> CreateTodoItem(CreateTodoForm requst);
    }
}
