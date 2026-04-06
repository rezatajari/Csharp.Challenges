using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace FinanceTracker.ValueObjects
{
    public record Money
    {
        private Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public decimal Amount { get; init; }
        public Currency Currency { get; init; }

        public static bool operator <(Money left, Money right)
        {
            CompareCurrency(left, right);
            return left.Amount < right.Amount;
        }

        public static bool operator >(Money left, Money right)
        {
            CompareCurrency(left, right);
            return left.Amount > right.Amount;
        }

        public static Money operator +(Money left, Money right)
        {
            CompareCurrency(left, right);
            return Create(left.Amount + right.Amount, left.Currency);
        }

        public static Money operator -(Money left, Money right)
        {
            CompareCurrency(left, right);
            if (left.Amount < right.Amount)
            {
                throw new InvalidOperationException("Resulting money cannot be negative");
            }
            return Create(left.Amount - right.Amount, left.Currency);
        }

        public static Money Create(decimal amount, Currency currency)
        => new Money(amount, currency);

        public static Money Default()
            => new Money(0, Currency.USD);

        private static void CompareCurrency(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException("Currency mismatch");
        }
    }
    public enum Currency
    {
        USD,
        EUR,
        GBP
    }
}
