using Domain.Exceptions;
namespace Domain.Entities
{
    public class TodoItem:BaseEntity
    {
       
        public string Title { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime? CompletedAt { get; set; }
        private TodoItem() { }

        private TodoItem(string title)
        {
            Title = title;
            IsCompleted = false;
        }

        public static TodoItem Create(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.");

            return new TodoItem(title);
        }
        public void Delete()
     => IsDeleted = true;

        public void Complete()
        {
            if (IsDeleted)
                throw new DomainException("Cannot complete a deleted todo.");

            if (IsCompleted)
                throw new DomainException("Todo is already completed.");

            IsCompleted = true;
            CompletedAt = DateTime.UtcNow;
        }

        public bool Update(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Title cannot be empty.");

            Title = newTitle;
            return true;
        }
    }
}
