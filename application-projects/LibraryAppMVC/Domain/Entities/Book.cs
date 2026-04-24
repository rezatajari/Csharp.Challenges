using Domain.Errors;
using Domain.Events;
using Domain.ValueObjects.Book;

namespace Domain.Entities
{
    public class Book
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public Isbn Id { get; }
        public Title Title { get; private set; }
        public  int AvailableCopies { get; private set; }
        public int TotalCopies { get; private set; }
        private Book(Isbn id,Title title,int totalCopies)
        {
            Id=id?? throw new ArgumentNullException(nameof(id));            
            Title=title?? throw new ArgumentNullException(nameof(title));
            TotalCopies=totalCopies>0 ? totalCopies : throw new ArgumentOutOfRangeException(nameof(totalCopies),
    "Total copies must be greater than zero.");

            AvailableCopies = totalCopies;
            EnsureInvariant();
        }

        public static Book Create(Isbn isbn, Title title, int totalCopies)
        {
            return new Book(isbn, title, totalCopies);
        }


        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private void EnsureInvariant()
        {
            if (AvailableCopies < 0)
                throw new InvalidOperationException("AvailableCopies cannot be negative.");

            if (AvailableCopies > TotalCopies)
                throw new InvalidOperationException("AvailableCopies cannot exceed TotalCopies.");
        }

        public Result BorrowCopy()
        {
            if (AvailableCopies<=0)
                return Result.Failure(GeneralErrors.Book.NoAvailableCopies);

            AvailableCopies--;
            _domainEvents.Add(new BookBorrowed(Id));

            EnsureInvariant();
            return Result.Success();
        }

        public Result ReturnCopy()
        {
            if (AvailableCopies>=TotalCopies)
                return Result.Failure(GeneralErrors.Book.AllCopiesReturned);

            AvailableCopies++;
            _domainEvents.Add(new BookReturned(Id));

            EnsureInvariant();
            return Result.Success();
        }

        public void ClearDomainEvents() {  _domainEvents.Clear(); }

    }
}
    