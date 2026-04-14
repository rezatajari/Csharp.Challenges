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

        public DbSet<Account> Accounts{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.OwnsOne(a => a.Balance, balance =>
                {
                    balance.Property(m => m.Amount).HasColumnName("BalanceAcmount").HasPrecision(18, 2);
                    balance.Property(m => m.Currency).HasColumnName("BalanceCurrency").HasConversion<string>();
                });
            });
        }
    }
}
