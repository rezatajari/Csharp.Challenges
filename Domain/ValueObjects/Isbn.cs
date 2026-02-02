using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public record Isbn
    {
        public string Value { get; }
        public Isbn(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("ISBN cannot be empty.",nameof(value));

            Value = value;
        }
    }
}
