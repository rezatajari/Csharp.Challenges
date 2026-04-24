using Domain.ValueObjects.Book;
using Domain.ValueObjects.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstractions
{
    public interface IMemberRepository
    {
        Task<Member?> GetByIdAsync(MemberId id);
        Task AddAsync(Member member);
        Task UpdateAsync(Member member);
    }
}
