using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace FinanceTracker.Entities
{
    public record Category
    {
        private Category(string name,string? description)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            this.Name = name;
            this.Description = description;
        }
        public string Name { get; init; }
        public string? Description { get;init; }

        public static Category Create(string name, string? description)
        {
            return new Category(name, description);
        }
    }
}
