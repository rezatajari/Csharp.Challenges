using AuthService.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u=>u.IsDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDeleted);
        }
        public DbSet<User> Users { get; set; }
    }
}
