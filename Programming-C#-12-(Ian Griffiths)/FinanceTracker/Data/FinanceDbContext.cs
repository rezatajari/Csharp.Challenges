using Azure.Core;
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
                .WithMany(a=>a.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.MapMoney(a => a.Amount, "Amount");

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

                entity.HasDiscriminator<TransactionType>("Type")
                .HasValue<IncomeTransaction>(TransactionType.Income)
                .HasValue<ExpenseTransaction>(TransactionType.Expense)
                .HasValue<TransferTransaction>(TransactionType.Transfer);
            });


            modelBuilder.Entity<TransferTransaction>(entity =>
            {
                entity.HasOne(t => t.ToAccount)
                      .WithMany()
                      .HasForeignKey(t => t.ToAccountId) 
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired(); 

                entity.Property(t => t.ToAccountId)
                      .HasColumnName("ToAccountId");
            });
        }
    }
}
