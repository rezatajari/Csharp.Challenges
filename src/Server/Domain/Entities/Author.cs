namespace Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public required string Name { get; set; }
        public string? About { get; set; }
        public string? Country { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
