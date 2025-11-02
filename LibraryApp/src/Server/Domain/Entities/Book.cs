using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int? PublishedYear { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
