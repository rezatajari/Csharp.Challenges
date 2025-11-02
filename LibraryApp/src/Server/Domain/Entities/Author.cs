using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = null!;
        public string? About { get; set; }
        public string? Country { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
