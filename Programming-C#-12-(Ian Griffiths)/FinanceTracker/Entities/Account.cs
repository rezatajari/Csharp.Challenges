using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using System.Text;

namespace FinanceTracker.Entities
{
    public class Account
    {
        private Account(string name, Money balance, TypeName type)
        {
            this.Id = Guid.NewGuid();
            ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            this.Name = name;

            if (balance.Amount < 0)
            {
                throw new ArgumentException("Balance cannot be negative.", nameof(balance));
            }
            this._initialBalance = balance;
            this.Balance= balance;
            this.Type = type;
            this.CreateAt = DateTime.Now;
        }

        private readonly Money _initialBalance;
        private readonly List<Transaction> _transactions = [];

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreateAt { get; private set; } 
        public Money Balance { get; private set; }
        public IEnumerable<Transaction> Transactions => _transactions.AsReadOnly();
        public TypeName Type { get; private set; }

        public static Account Create(string name, Money balance, TypeName type)
        {
            return new Account(name, balance, type);
        }

        public Transaction AddExpense(Money amount, Category category, string? description, DateTime createAt)
        {
            EnsureSameCurrency(amount);

            if (Balance < amount)
            {
                throw new InvalidOperationException("Insufficient balance for this transaction.");
            }

            var transaction = Transaction.CreateForAccount(amount, TransactionType.Expense,
                category, this, description, createAt);

            this.Balance -= amount;
            CreateAndStore(transaction);

            return transaction;
        }

        public Transaction AddIncome(Money amount, Category category,
            string? description, DateTime createAt)
        {
            EnsureSameCurrency(amount);

            var transaction = Transaction.CreateForAccount(amount, TransactionType.Income,
                category, this, description, createAt);

            this.Balance += amount;
            CreateAndStore(transaction);

            return transaction;
        }

        public Money GetBalanceAtDate(DateTime targetDate)
        {

            if (targetDate > DateTime.Now)
            {
                return this.Balance;
            }
            else if (targetDate < this.CreateAt)
            {
                return Money.Create(0, this.Balance.Currency);
            }

            Money incomeAmount = _initialBalance;
            Money expenseAmount = Money.Create(0, this.Balance.Currency);
            foreach (var transaction in _transactions)
            {
                if (transaction.CreateAt > targetDate) continue;
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


        private void EnsureSameCurrency(Money amount)
        {
            if (this.Balance.Currency != amount.Currency)
            {
                throw new InvalidOperationException(
                    "Currency mismatch between account balance and transaction amount.");
            }
        }
        private void CreateAndStore(Transaction transaction) => _transactions.Add(transaction);
    }

    public enum TypeName
    {
        Cash,
        Bank,
        CreditCard,
        Investment
    }
}
