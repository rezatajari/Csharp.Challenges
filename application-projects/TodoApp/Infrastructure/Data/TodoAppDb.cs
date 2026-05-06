using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class TodoAppDb(DbContextOptions<TodoAppDb> options) : DbContext(options)
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>(t =>
            {
                t.HasKey(t => t.Id);
                t.HasQueryFilter(t => !t.IsDeleted);
            });
        }
    }
}
