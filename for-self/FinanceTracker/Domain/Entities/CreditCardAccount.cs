using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class CreditCardAccount : BaseAccount
    {
        protected CreditCardAccount() : base() { }
        private CreditCardAccount(string name, Money initialBalance, Money limit,AccountType type)
            : base(name, initialBalance, type)
        {
            CreditLimit = limit;
        }
        public Money CreditLimit { get; private set; }

        public static CreditCardAccount Create(string name, Money initialBalance, Money limit,AccountType type)
        {
            if (limit.Amount < 0) throw new ArgumentException("Limit must be positive.");
            return new CreditCardAccount(name, initialBalance, limit,type);
        }

        public override Transaction Deposit(Money amount, TransactionType type, Category category,
          string? description, DateTime createdAt)
        {
            EnsureSameCurrency(amount);
            this.Balance += amount;
            var transaction = Transaction.Create(amount, type, category, description, createdAt);
            StoreTransaction(transaction);
            return transaction;
        }

        public override Transaction Withdraw(Money amount, TransactionType type, Category category, string? description, DateTime createdAt)
        {
            EnsureSameCurrency(amount);
            EnsureAvailableFunds(amount);

            this.Balance -= amount;
            var transaction = Transaction.Create(amount, type, category, description, createdAt);
            StoreTransaction(transaction);
            return transaction;
        }

        public override Transaction TransferTo(Money amount, TransactionType type, Category category,
            string? description, DateTime createdAt, BaseAccount toAccount)
        {
            EnsureSameCurrency(amount);
            EnsureAvailableFunds(amount);
            this.Balance -= amount;
            var transaction = Transaction.Create(amount, type, category, description, createdAt);
            StoreTransaction(transaction);
            toAccount.Deposit(amount, type, category, description, createdAt);
            return transaction;
        }
    }
}
