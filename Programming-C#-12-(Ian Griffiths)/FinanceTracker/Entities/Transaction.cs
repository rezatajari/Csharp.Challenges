using FinanceTracker.Interfaces;
using FinanceTracker.ValueObjects;

namespace FinanceTracker.Entities
{
    public class Transaction:BaseEntity
    {
        private Transaction(Money amount, TransactionType type, Category category,
            BaseAccount account, string? description, DateTime createAt)
        {
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
            this.CreatedAt = createAt;

            this.Description = description;
        }

        protected Transaction() { }

        public int AccountId { get; set; }
        public Money Amount { get; private set; }
        public TransactionType Type { get;private set; }
        public Category Category { get; private set; }
        public string? Description { get; private set; }
        public BaseAccount Account { get; private set; }

        internal static Transaction CreateForAccount(Money amount, TransactionType type, Category category,
            BaseAccount account, string? description, DateTime createAt)
        {
            if (category.Type != type)
                throw new InvalidOperationException($"Category type {category.Type} does not match transaction type {type}.");

            return new Transaction(amount, type, category, account, description, createAt);
        }
    }

    public enum TransactionType
    {
        Income,
        Expense,
        Transfer
    }
}
