using Domain.Events;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Book
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public Isbn Isbn { get;private set; }
        public Title Title { get; private set; }
        public  int AvailableCopies { get; private set; }
        public int TotalCopies { get; private set; }
        public Book(Isbn isbn,Title title,int totalCopies)
        {
            Isbn=isbn?? throw new ArgumentNullException(nameof(isbn));            
            Title=title?? throw new ArgumentNullException(nameof(title));
            TotalCopies=totalCopies>0 ? totalCopies : throw new ArgumentOutOfRangeException("Total copies must be greater than zero.", nameof(totalCopies));
            AvailableCopies=totalCopies;
            EnsureInvariant();
        }
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
                return Result.Failure(Errors.Book.NoAvailableCopies);

            AvailableCopies--;
            _domainEvents.Add(new BookBorrowed(Isbn));
            EnsureInvariant();
            return Result.Success();
        }

        public Result ReturnCopy()
        {
            if (AvailableCopies>=TotalCopies)
                return Result.Failure(Errors.Book.AllCopiesReturned);

            AvailableCopies++;
            EnsureInvariant();
            return Result.Success();
        }
    }
}
    