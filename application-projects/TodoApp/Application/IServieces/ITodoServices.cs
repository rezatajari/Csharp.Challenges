using Application.Shared.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServieces
{
    public interface ITodoServices
    {
        Task<TodoItem> CreateTodoItem(CreateTodoForm requst);
    }
}
