using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public record Title
    {
        public string Value { get; }

        public Title(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Title cannot be empty.", nameof(value));

            Value = value;
        }

        public virtual bool Equals(Title? other)
        {
            if (other is null) return false;
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode(StringComparison.Ordinal);
        }
    }
}
