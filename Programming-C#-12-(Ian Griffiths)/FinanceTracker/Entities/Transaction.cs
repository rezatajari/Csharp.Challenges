using FinanceTracker.Interfaces;
using FinanceTracker.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public class Transaction:IEntity
    {
        private Transaction(Money amount, TransactionType type, Category category,
            IAccount account, string? description, DateTime createAt)
        {
            this.Id = Guid.NewGuid();
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
        public IAccount Account { get; private set; }
        public string? Description { get; private set; }

        internal static Transaction CreateForAccount(Money amount, TransactionType type, Category category,
            IAccount account, string? description, DateTime createAt)
        {
            if (category.Type != type)
                throw new InvalidOperationException($"Category type {category.Type} does not match transaction type {type}.");

            return new Transaction(amount, type, category, account, description, createAt);
        }
    }

    public enum TransactionType
    {
        Income,
        Expense
    }
}
