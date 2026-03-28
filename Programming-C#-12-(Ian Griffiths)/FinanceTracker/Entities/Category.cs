using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace FinanceTracker.Entities
{
    public class Category
    {
        private Category(string name,string? description)
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));
            this.Name = name;
            this.Description = description;
        }
        public string Name { get; private set; }
        public string? Description { get;private set; }

        public static Category Create(string name, string? description)
        {
            return new Category(name, description);
        }
    }
}
