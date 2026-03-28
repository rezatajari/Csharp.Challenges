using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace FinanceTracker.Entities
{
    public record Money
    {
        private Money(decimal amount, Currency currency)
        {
            if (amount == 0)
                throw new ArgumentException("Amount cannot zero");
            this.Amount = amount;
            this.Currency = currency;
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
            return Create(left.Amount - right.Amount, left.Currency);
        }

        public static Money Create(decimal amount, Currency currency)
        => new Money(amount, currency);

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
