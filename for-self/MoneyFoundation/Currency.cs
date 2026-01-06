using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyFoundation
{
    public readonly struct Currency(string name, decimal rate)
    {
        public string Name { get; } = string.IsNullOrEmpty(name)
            ? throw new NullReferenceException("The name is required")
            : name;
        public decimal Rate { get; } = rate > 0
            ? rate
            : throw new ArgumentOutOfRangeException(nameof(rate), "Rate must be positive.");
    }
}
