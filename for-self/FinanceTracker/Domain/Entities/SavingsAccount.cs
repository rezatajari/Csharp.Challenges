using FinanceTracker.ValueObjects;
using System.Data;

namespace Domain.Entities
{
    public class SavingsAccount : BaseAccount
    {
        protected SavingsAccount():base() {}
        private SavingsAccount(string name, Money initialBalance, TypeName type) 
            : base(name, initialBalance, type)
        {
            if (initialBalance.Amount < 0)
            {
                throw new ArgumentException("Balance cannot be negative.", nameof(initialBalance));
            }
        }
        public static SavingsAccount Create(string name, Money balance, TypeName type)
        {
            return new SavingsAccount(name, balance, type);
        }

        public override Transaction Withdraw(Money amount, Category category, string? description, DateTime createdAt)
        {
            EnsureSameCurrency(amount);

            if (Balance < amount)
            {
                throw new InsufficientFundsException("Insufficient balance for this transaction.");
            }

            var transaction = Transaction.Create(amount, TransactionType.Expense,
                category, this, description, createdAt);

            this.Balance -= amount;
            StoreTransaction(transaction);

            return transaction;
        }

        public override Transaction Deposit(Money amount, Category category,
            string? description, DateTime createdAt)
        {
            EnsureSameCurrency(amount);

            var transaction = Transaction.Create(amount, TransactionType.Income,
                category, this, description, createdAt);

            this.Balance += amount;
            StoreTransaction(transaction);

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

        public TransferResult TransferTo(SavingsAccount destination, Money amount, DateTime transferDate,
              string? description = "Founds Transfer")
        {
            if (this.Id == destination.Id)
                throw new InvalidOperationException("Cannot transfer to the same account.");

            EnsureSameCurrency(destination.Balance);

            var transferCategory = Category.Create("Transfer", "Internal Transfer", TransactionType.Expense);
            Transaction sourceTx = this.Withdraw(amount, transferCategory, description, transferDate);
            Transaction destTx = destination.Deposit(amount, transferCategory, description, transferDate);

            return new TransferResult(sourceTx, destTx);
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
