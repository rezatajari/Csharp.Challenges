using Domain.Entities;
using Domain.ValueObjects.Book;

namespace Domain.Abstractions
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(Isbn id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
    }
}
