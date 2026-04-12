using ToDoList.API.Shared;

namespace ToDoList.API.Entites
{
    public class TodoItem
    {
        public int Id { get; private set; }
        public string Title { get;private set; }
        public bool IsCompleted { get; private set; }

        private TodoItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
               throw new ArgumentException("Title cannot be empty.",nameof(title));
        }

        public static TodoItem Create(string title)
        {
            return new TodoItem(title);
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
    }

}
