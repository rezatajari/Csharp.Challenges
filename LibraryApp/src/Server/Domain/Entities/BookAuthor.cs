using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public Book Book { get; set; } = null!;
        public Author Author { get; set; } = null!;
    }
}
