using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Book
    {
        public Isbn Isbn { get;private set; }
        public Title Title { get; private set; }

        public Book(Isbn isbn,Title title)
        {
            Isbn=isbn?? throw new ArgumentNullException(nameof(isbn));            
            Title=title?? throw new ArgumentNullException(nameof(title));
        }
    }
}
    