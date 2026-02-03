using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class BookBorrowed:IDomainEvent
    {
        public Isbn Isbn{ get;} 
        public DateTime OccurredAt { get; }

        public BookBorrowed(Isbn isbn)
        {
            Isbn = isbn;
            OccurredAt = DateTime.UtcNow;
        }

    }
}
