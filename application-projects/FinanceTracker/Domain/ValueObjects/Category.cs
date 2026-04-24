using Domain.Entities;
using System.Text.Json.Serialization;

namespace Domain.ValueObjects
{
    public record Category
    {
        protected Category() { }
        [JsonConstructor]
        private Category(string name,string? description)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(name));

            this.Name = name.Trim();
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
