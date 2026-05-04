using Domain.ValueObjects;
using System.Data;

namespace Domain.Entities
{
    public class SavingsAccount : BaseAccount
    {
        protected SavingsAccount() : base() { }
        private SavingsAccount(int userId,string name, Money initialBalance, AccountType type)
            : base(userId,name, initialBalance, type)
        {
            if (initialBalance.Amount < 0)
            {
                throw new ArgumentException("Balance cannot be negative.", nameof(initialBalance));
            }
        }
        public static SavingsAccount Create(int userId,string name, Money balance, AccountType type)
        {
            return new SavingsAccount(userId,name, balance, type);
        }

        public override Transaction Deposit(Money amount,TransactionType type, Category category,
          string? description, DateTime createdAt)
        {
            EnsureSameCurrency(amount);
            this.Balance += amount;
            var transaction = Transaction.Create(amount, type, category, description, createdAt);
            StoreTransaction(transaction);
            return transaction;
        }

        public override Transaction Withdraw(Money amount, TransactionType type,Category category, string? description, DateTime createdAt)
        {
            EnsureSameCurrency(amount);
            EnsureAvailableFunds(amount);

            this.Balance -= amount;
            var transaction = Transaction.Create(amount, type, category, description, createdAt);
            StoreTransaction(transaction);
            return transaction;
        }

        public override Transaction TransferTo(Money amount,TransactionType type,  Category category, 
            string? description, DateTime createdAt, BaseAccount toAccount)
        {
            EnsureSameCurrency(amount);
            EnsureAvailableFunds(amount);
            this.Balance -= amount;
            var transaction = Transaction.Create(amount, type, category, description, createdAt);
            StoreTransaction(transaction);

            var amountForDeposit = Money.Create(amount.Amount, amount.Currency);
            var categoryForDeposit = Category.Create(category.Name, category.Description);
            toAccount.Deposit(amountForDeposit, type, categoryForDeposit, description, createdAt);
            return transaction;
        }
    }
}
