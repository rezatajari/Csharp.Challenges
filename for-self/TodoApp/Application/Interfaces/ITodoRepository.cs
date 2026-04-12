using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ITodoRepository
    {
        TodoItem? GetById(Guid id);
        void Add(TodoItem todo);
        List<TodoItem> GetAll();
    }
}
