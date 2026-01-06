using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
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

        public static bool operator ==(Currency left,Currency right)
            => (left.Name == right.Name && left.Rate == right.Rate) ? true : false;

        public static bool operator !=(Currency left, Currency right)
            => !(left == right);
    }
}
