using Domain.ValueObjects.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class BookReturned:IDomainEvent
    {
        public Isbn Isbn { get;  }
        public DateTime OccurredAt { get;  }

        public BookReturned(Isbn isbn)
        {
            Isbn = isbn;
            OccurredAt = DateTime.UtcNow;
        }
    }
}
