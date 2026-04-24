using HabitTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Api.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)  
            : base(options) { }

        public DbSet<Habit> Habit { get; set; }
    }
}
