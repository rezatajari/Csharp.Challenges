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

        Task<IEnumerable<TodoItem>> ITodoRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
            => await _context.FindAsync<TodoItem>(id);

        public TodoItem? GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
