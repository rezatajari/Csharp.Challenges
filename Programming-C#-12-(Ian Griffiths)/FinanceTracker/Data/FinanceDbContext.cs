using FinanceTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Data
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
            : base(options) { }

        public DbSet<BaseAccount> BaseAccounts { get; set; }
        public DbSet<SavingsAccount> SavingsAccount { get; set; }
        public DbSet<CreditCardAccount> CreditCardAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<IncomeTransaction> IncomeTransactions { get; set; }
        public DbSet<ExpenseTransaction> ExpenseTransactions { get; set; }
        public DbSet<TransferTransaction> TransferTransactions { get; set; }

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

                entity.HasOne(t => t.Account)
                .WithMany(t => t.Transactions)
                .HasForeignKey("AccountId");

                entity.MapMoney(a => a.Amount, "Balance");

                entity.OwnsOne(t => t.Category, category =>
                {
                    category.Property(c => c.Name)
                    .HasColumnName("CategoryName");

                    category.Property(c => c.Type)
                    .HasColumnName("CategoryType")
                    .HasConversion<string>();

                    category.Property(c => c.Description)
                    .HasColumnName("CategoryDescription");
                });
            });
        }
    }
}
