using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class BorrowingService
    {
        public Result Borrow(Member member,Book book)
        {
            var memberResult=member.CanBorrow();
            if (!memberResult.IsSuccess)
                return memberResult;

            var bookResult=book.BorrowCopy();
            if (!bookResult.IsSuccess)
                return bookResult;

            member.RegisterBorrow(book.Isbn);

            return Result.Success();    
        }
    }
}
