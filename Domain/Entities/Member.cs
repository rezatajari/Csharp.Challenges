using Domain.ValueObjects.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects.Book
{
    public class Member
    {
        private int _borrowedCount;
        private const int BorrowLimit = 3;
        private Member()
        {
            _borrowedCount = 0;
        }

        public static Member Create()
        {
            return new Member();
        }
        public Result CanBorrow()
        {
            if (_borrowedCount >= BorrowLimit)
                return Result.Failure("You have reached the maximum number of borrowed books.");

            return Result.Success();
        }

        public Result RegisterBorrow()
        {
            var result = CanBorrow();
            if (!result.IsSuccess)
                return result;

            _borrowedCount++;
            return Result.Success();
        }

        public Result UnregisterBorrow()
        {
            if (_borrowedCount<=0)
                return Result.Failure("Member has no borrowed books to return.");

            _borrowedCount--;
            return Result.Success();
        }
    }
}
