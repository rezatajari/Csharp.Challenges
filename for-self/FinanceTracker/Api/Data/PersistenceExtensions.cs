using FinanceTracker.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FinanceTracker.Data
{
    public static class PersistenceExtensions
    {
        public static void MapMoney<T>(this EntityTypeBuilder<T> builder,Expression<Func<T,Money>> selector,string name)
            where T : class
        {
            builder.OwnsOne( selector!, model =>
            {
                model.Property(m => m.Amount)
                .HasColumnName(name + "Amount")
                .HasPrecision(18, 2);

                model.Property(m => m.Currency)
                .HasColumnName(name + "Currency")
                .HasConversion<string>();
            });
        }
    }
}
