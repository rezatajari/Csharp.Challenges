using FinanceTracker.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Data
{
    public class FinanceDbContext:DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
            :base(options){}

        public DbSet<BaseAccount> BaseAccounts { get; set; }
        public DbSet<SavingsAccount> SavingsAccount { get; set; }
        public DbSet<CreditCardAccount> CreditCardAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseAccount>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.OwnsOne(a => a.Balance, balance =>
                {
                    balance.Property(m => m.Amount)
                    .HasColumnName("BalanceAmount")
                    .HasPrecision(18, 2);

                    balance.Property(m => m.Currency)
                    .HasColumnName("BalanceCurrency")
                    .HasConversion<string>();
                });
            });
        }
    }
}
