using FinanceTracker.ValueObjects;

namespace Domain.Entities
{
    public abstract class Transaction : BaseEntity
    {

        public int AccountId { get; private set; }
        public Money Amount { get; private set; }
        public Category Category { get; private set; }
        public string? Description { get; private set; }
        public BaseAccount Account { get; private set; }
        public TransactionType Type { get; protected set; }

        protected Transaction(Money amount, TransactionType type, Category category,
            BaseAccount account, string? description, DateTime createdAt)
        {
            this.Amount = amount;
            ArgumentNullException.ThrowIfNull(category, nameof(category));
            this.Category = category;

            ArgumentNullException.ThrowIfNull(account, nameof(account));
            this.Account = account;

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
            BaseAccount account, string? description, DateTime createdAt, BaseAccount? toAccount = null)
        {
            if (category.Type != type)
                throw new InvalidOperationException("Category/Type mismatch");

            return type switch
            {
                TransactionType.Income => new IncomeTransaction(amount, category, account, description, createdAt),
                TransactionType.Expense => new ExpenseTransaction(amount, category, account, description, createdAt),
                TransactionType.Transfer => (toAccount == null)
                ? throw new ArgumentException("Transfer requires a destination account.")
                : new TransferTransaction(amount, category, account, toAccount!, description, createdAt),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }
    }


    public class IncomeTransaction : Transaction
    {
        internal IncomeTransaction(Money amount, Category category,
            BaseAccount account, string? description, DateTime createdAt)
            : base(amount,TransactionType.Income, category, account, description, createdAt) { }
        protected IncomeTransaction():base() { }
    }

    public class ExpenseTransaction : Transaction
    {
        internal ExpenseTransaction(Money amount, Category category,
            BaseAccount account, string? description, DateTime createdAt)
            : base(amount,TransactionType.Expense, category, account, description, createdAt) { }
        protected ExpenseTransaction() : base() { }
    }

    public class TransferTransaction : Transaction
    {
        public int ToAccountId { get; private set; }
        public BaseAccount ToAccount { get; private set; }

        internal TransferTransaction(Money amount, Category category, BaseAccount fromAccount,
            BaseAccount toAccount, string? description, DateTime createdAt)
        : base(amount,TransactionType.Transfer, category, fromAccount, description, createdAt)
        {
            ArgumentNullException.ThrowIfNull(toAccount, nameof(toAccount));
            this.ToAccount = toAccount;
        }
        protected TransferTransaction() : base() { }
    }

    public enum TransactionType
    {
        Income,
        Expense,
        Transfer
    }
}
