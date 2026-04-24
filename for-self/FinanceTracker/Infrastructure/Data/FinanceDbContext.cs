using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
            : base(options) { }

        public DbSet<BaseAccount> BaseAccounts { get; set; }
        public DbSet<SavingsAccount> SavingsAccount { get; set; }
        public DbSet<CreditCardAccount> CreditCardAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseAccount>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.MapMoney(a=>a.Balance, "Balance");
            });

            modelBuilder.Entity<CreditCardAccount>(entity =>
            {
               entity.MapMoney(c=>c.CreditLimit, "CreditLimit");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.MapMoney(a => a.Amount, "Amount");

                entity.OwnsOne(t => t.Category, category =>
                {
                    category.Property(c => c.Name).HasColumnName("CategoryName");
                    category.Property(c => c.Description).HasColumnName("CategoryDescription");
                });

                entity.HasOne(t => t.Account)
                .WithMany(a=>a.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.Property(t => t.Type)
                      .HasColumnName("Type")
                      .HasConversion<string>();
            });
        }
    }
}
