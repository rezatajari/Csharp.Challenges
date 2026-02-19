using Domain.ValueObjects.Member;

namespace Domain.ValueObjects.Book
{
    public class Member
    {
        private int _borrowedCount;
        private const int BorrowLimit = 3;
        private Member(MemberId id)
        {
            Id= id;
            _borrowedCount = 0;
        }

        public MemberId Id { get;}

        public static Member Create()
        {
            return new Member(MemberId.New());
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
