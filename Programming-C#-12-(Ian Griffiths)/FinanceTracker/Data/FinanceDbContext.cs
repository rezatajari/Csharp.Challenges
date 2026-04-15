using FinanceTracker.Entities;
using FinanceTracker.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FinanceTracker.Data
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
            : base(options) { }

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

            modelBuilder.Entity<CreditCardAccount>(entity =>
            {
                entity.OwnsOne(m => m.CreditLimit, creditLimit =>
                {
                    creditLimit.Property(m => m.Amount)
                    .HasColumnName("CreditLimitAmount")
                    .HasPrecision(18, 2);

                    creditLimit.Property(m => m.Currency)
                    .HasColumnName("CreditLimitCurrency")
                    .HasConversion<string>();
                });
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.OwnsOne(a => a.Amount, balance =>
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
