using HabitTracker.Api.Data;
using HabitTracker.Api.Models;

namespace HabitTracker.Api.Repository
{
    public class HabitRepository
    {
        private readonly AppDbContext _dbContext;
        public HabitRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async void Add(Habit habit)
        {
            await _dbContext.AddAsync(habit);
            await _dbContext.SaveChangesAsync();
        }
    }
}
