using Domain.Exceptions;
using Domain.Shared;
using Domain.ValueObjects;
using System.Data;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SavingsAccount : BaseAccount
    {
        protected SavingsAccount() : base() { }
        private SavingsAccount(string name, Money initialBalance, AccountType type)
            : base(name, initialBalance, type)
        {
            if (initialBalance.Amount < 0)
            {
                throw new ArgumentException("Balance cannot be negative.", nameof(initialBalance));
            }
        }
        public static SavingsAccount Create(string name, Money balance, AccountType type)
        {
            return new SavingsAccount(name, balance, type);
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
            toAccount.Deposit(amount, type, category, description, createdAt);
            return transaction;
        }

        public Money GetBalanceAtDate(DateTime targetDate)
        {

            if (targetDate > DateTime.Now)
            {
                return this.Balance;
            }
            else if (targetDate < this.CreatedAt)
            {
                return Money.Create(0, this.Balance.Currency);
            }

            Money incomeAmount = _initialBalance;
            Money expenseAmount = Money.Create(0, this.Balance.Currency);
            foreach (var transaction in Transactions)
            {
                if (transaction.CreatedAt > targetDate) continue;
                if (transaction == null) continue;

                (incomeAmount, expenseAmount) = transaction.Type switch
                {
                    TransactionType.Income => (incomeAmount + transaction.Amount, expenseAmount),
                    TransactionType.Expense => (incomeAmount, expenseAmount + transaction.Amount),
                    _ => (incomeAmount, expenseAmount)
                };
            }

            return incomeAmount - expenseAmount;
        }

        public List<Transaction> GetTransactionsByCategory(Category category)
        => Transactions.Where(tx => tx.Category == category).ToList();

        public decimal GetTotalSpendingByCategory(Category category)
        => Transactions
                .Where(tx => tx.Category == category && tx.Type == TransactionType.Expense)
                .Sum(a => a.Amount.Amount);

        public List<CategorySummary> GetSpendingSummoryByCategory()
         => Transactions
                    .Where(tx => tx.Type == TransactionType.Expense)
                    .GroupBy(tx => tx.Category.Name)
                    .Select(group => new CategorySummary(
                        group.Key,   // The Name
                        group.Sum(t => t.Amount.Amount),  // The Sum
                        group.Count() // The Count
                        ))
                    .ToList();

        public Transaction this[int index]
        {
            get
            {
                return Transactions.ElementAt(index);
            }
        }

    }
}
