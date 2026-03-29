using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace FinanceTracker.Entities
{
    public record Category
    {
        private Category(string name,string? description,TransactionType type)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(name));

            this.Name = name.Trim();
            this.Description = description;
            this.Type = type;
        }
        public string Name { get; init; }
        public string? Description { get;init; }
        public TransactionType Type { get; init; }

        public static Category Create(string name, string? description,TransactionType type)
        {
            return new Category(name, description,type);
        }
    }
}
