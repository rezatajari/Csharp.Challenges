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
        public  int AvailableCopies { get; private set; }
        public int TotalCopies { get; private set; }
        public Book(Isbn isbn,Title title,int totalCopies)
        {
            Isbn=isbn?? throw new ArgumentNullException(nameof(isbn));            
            Title=title?? throw new ArgumentNullException(nameof(title));
            TotalCopies=totalCopies>0 ? totalCopies : throw new ArgumentOutOfRangeException("Total copies must be greater than zero.", nameof(totalCopies));
            AvailableCopies=totalCopies;
        }

        public void BorrowCopy()
        {
            if (AvailableCopies<=0)
                throw new InvalidOperationException("No copies available to borrow.");

            AvailableCopies--;
        }

        public void ReturnCopy()
        {
            if (AvailableCopies>=TotalCopies)
                throw new InvalidOperationException("All copies are already returned.");
            AvailableCopies++;
        }
    }
}
    