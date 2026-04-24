using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Transaction : BaseEntity
    {

        public int AccountId { get; private set; }
        public Money Amount { get; private set; }
        public Category Category { get; private set; }
        public string? Description { get; private set; }
        public BaseAccount Account { get; private set; }
        public TransactionType Type { get; private set; }

        protected Transaction(Money amount, TransactionType type, Category category,
            string? description, DateTime createdAt)
        {
            this.Amount = amount;
            ArgumentNullException.ThrowIfNull(category, nameof(category));
            this.Category = category;

            if (createdAt == default)
            {
                throw new ArgumentException("Transaction data must be a valid date.", nameof(createdAt));
            }
            this.CreatedAt = createdAt;
            this.Description = description;
            this.Type = type;
        }

        protected Transaction() { }

        public static Transaction Create(Money amount, TransactionType type, Category category,
           string? description, DateTime createdAt)
        {
            return new Transaction(amount, type, category, description, createdAt);
        }
    }


    public enum TransactionType
    {
        Income,
        Expense,
        Transfer
    }
}
