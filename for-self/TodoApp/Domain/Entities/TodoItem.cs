using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TodoItem
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private TodoItem() { }

        public TodoItem(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            IsCompleted = false;
            CreatedAt = DateTime.UtcNow;
        }

        public void Complete()
        {
            if (IsCompleted)
                throw new DomainException("Todo is already completed.");

            IsCompleted = true;
        }

        public void Rename(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Title cannot be empty.");

            Title = newTitle;
        }
    }
}
