namespace Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int? PublishedYear { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
