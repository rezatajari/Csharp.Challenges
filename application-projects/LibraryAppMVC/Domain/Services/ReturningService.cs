using Domain.Entities;
using Domain.ValueObjects.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class ReturningService
    {
        public Result Return(Member member, Book book)
        {
            var bookResult = book.ReturnCopy();
            if (!bookResult.IsSuccess)
                return bookResult;

            member.UnregisterBorrow();
            return Result.Success();
        }
    }
}
