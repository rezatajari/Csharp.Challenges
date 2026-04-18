using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System.Net;

namespace Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoAppDb _context;
        public TodoRepository(TodoAppDb context)
        {
            _context=context;
        }

        public async Task AddAsync(TodoItem todo)
           => await _context.TodoItems.AddAsync(todo);

        public IEnumerable<TodoItem> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TodoItem? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public TodoItem? GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
