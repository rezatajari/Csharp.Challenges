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
    }
}
