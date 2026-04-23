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
           string? description, DateTime createdAt)
        {
            return new Transaction(amount, type, category, description, createdAt);
        }
    }


    //public class IncomeTransaction : Transaction
    //{
    //    internal IncomeTransaction(Money amount, Category category,
    //        BaseAccount account, string? description, DateTime createdAt)
    //        : base(amount,TransactionType.Income, category, account, description, createdAt) { }
    //    protected IncomeTransaction():base() { }
    //    public static Transaction Create(Money amount, TransactionType type, Category category,
    //BaseAccount account, string? description, DateTime createdAt)
    //=> new IncomeTransaction(amount, category, account, description, createdAt);
    //}

    //public class ExpenseTransaction : Transaction
    //{
    //    internal ExpenseTransaction(Money amount, Category category,
    //        BaseAccount account, string? description, DateTime createdAt)
    //        : base(amount,TransactionType.Expense, category, account, description, createdAt) { }
    //    protected ExpenseTransaction() : base() { }
    //    public static Transaction Create(Money amount, TransactionType type, Category category,
    //     BaseAccount account, string? description, DateTime createdAt)
    //     => new ExpenseTransaction(amount, category, account,  description, createdAt);
    //}

    //public class TransferTransaction : Transaction
    //{
    //    public int ToAccountId { get; private set; }
    //    public BaseAccount ToAccount { get; private set; }

    //    internal TransferTransaction(Money amount, Category category, BaseAccount fromAccount,
    //        BaseAccount toAccount, string? description, DateTime createdAt)
    //    : base(amount,TransactionType.Transfer, category, fromAccount, description, createdAt)
    //    {
    //        ArgumentNullException.ThrowIfNull(toAccount, nameof(toAccount));
    //        this.ToAccount = toAccount;
    //    }
    //    protected TransferTransaction() : base() { }

    //    public static Transaction Create(Money amount,  Category category,
    //       BaseAccount fromAccount, string? description, DateTime createdAt, BaseAccount toAccount)
    //       =>  new TransferTransaction(amount, category, fromAccount, toAccount, description, createdAt);
    //}

    public enum TransactionType
    {
        Income,
        Expense,
        Transfer
    }
}
