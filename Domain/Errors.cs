using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public static class Errors
    {
        public static class Book
        {
            public const string NoAvailableCopies = "No available copies of the book.";
            public const string AllCopiesReturned = "All copies of the book have been returned.";
        }
    }
}
