using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public class Transaction
    {
        private Transaction(Money amount, TransactionType type, Category category,
            Account account, string? description, DateTime createAt)
        {
            this.Id = Guid.NewGuid();
            if (amount.Amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            }
            this.Amount = amount;

            this.Type = type;

            ArgumentNullException.ThrowIfNull(category, nameof(category));
            this.Category = category;

            ArgumentNullException.ThrowIfNull(account, nameof(account));
            this.Account = account;

            if (createAt == default)
            {
                throw new ArgumentException("Transaction data must be a valid date.",nameof(createAt));
            }
            this.CreateAt = createAt;

            this.Description = description;
        }

        public Guid Id { get;private set; }
        public Money Amount { get; private set; }
        public TransactionType Type { get;private set; }
        public DateTime CreateAt { get; private set; }
        public Category Category { get; private set; }
        public Account Account { get; private set; }
        public string? Description { get; private set; }

        internal static Transaction Create(Money amount, TransactionType type, Category category,
            Account account, string? description, DateTime createAt)
        {
            return new Transaction(amount, type, category, account, description, createAt);
        }
    }

    public enum TransactionType
    {
        Income,
        Expense
    }
}
