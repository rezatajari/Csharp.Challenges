using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options) { }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<BookAuthor> BookAuthors => Set<BookAuthor>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>(
                config =>
                {
                    config.HasKey(ba => new { ba.BookId, ba.AuthorId });
                    config.HasOne(ba => ba.Book)
                          .WithMany(b => b.BookAuthors)
                          .HasForeignKey(ba => ba.BookId);
                });

            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Author>()
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
