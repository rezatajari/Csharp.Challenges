using Domain.Exceptions;
using Domain.ValueObjects;
using System.Security.Cryptography;

namespace Domain.Entities
{
    public abstract class BaseAccount : BaseEntity
    {
        protected readonly Money _initialBalance;

        // For database (ef core) mapping
        private ICollection<Transaction> _transactions = new List<Transaction>();
        public string Name { get; protected set; }
        public int UserId { get;private set; }
        public User User { get;private set; } = default!;
        public Money Balance { get; protected set; }
        public AccountType Type { get; protected set; }

        // For expose
        public IEnumerable<Transaction> Transactions => _transactions;

        protected BaseAccount(int userId,string name, Money initialBalance, AccountType type)
        {
            if (userId <= 0) throw new ArgumentException("Invalid User ID");

            ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
            Balance = initialBalance;
            Type = type;
            CreatedAt = DateTime.Now;
            _initialBalance = Balance;
        }

        protected BaseAccount() { }

        protected void StoreTransaction(Transaction transaction) => _transactions.Add(transaction);
        protected void EnsureSameCurrency(Money amount)
        {
            if (this.Balance.Currency != amount.Currency)
            {
                throw new InvalidOperationException(
                    "Currency mismatch between account balance and transaction amount.");
            }
        }
        protected void EnsureAvailableFunds(Money amount)
        {
            if (Balance < amount)
                throw new InsufficientFundsException("Insufficient balance for this transaction.");
        }
        public abstract Transaction Deposit(Money amount, TransactionType type, Category category,
            string? description, DateTime createdAt);
        public abstract Transaction Withdraw(Money amount, TransactionType type, Category category,
            string? description, DateTime createdAt);

        public abstract Transaction TransferTo(Money amount, TransactionType type, Category category,
            string? description, DateTime createdAt, BaseAccount toAccount);
    }

    public enum AccountType
    {
        Savings,
        CreditCard
    }
}
