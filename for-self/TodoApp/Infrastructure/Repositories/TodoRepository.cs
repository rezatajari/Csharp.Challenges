using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
            => await _context.TodoItems.ToListAsync();

        public async Task<TodoItem?> GetByIdAsync(int id)
            => await _context.FindAsync<TodoItem>(id);

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
