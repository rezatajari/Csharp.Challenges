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
            this.Balance = balance;

            this.Type = type;
        }

        private readonly List<Transaction> _transactions = [];

        public Guid Id { get; private set; }
        public string Name { get; private set; }
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

            var transaction = Transaction.Create(amount, TransactionType.Expense,
                category, this, description, createAt);

            this.Balance -= amount;
            CreateAndStore(transaction);

            return transaction;
        }

        public Transaction AddIncome(Money amount, Category category,
            string? description, DateTime createAt)
        {
            EnsureSameCurrency(amount);

            var transaction = Transaction.Create(amount, TransactionType.Income,
                category, this, description, createAt);

            this.Balance += amount;
            CreateAndStore(transaction);

            return transaction;
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
