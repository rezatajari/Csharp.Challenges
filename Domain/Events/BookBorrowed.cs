using Domain.ValueObjects.Book;

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
