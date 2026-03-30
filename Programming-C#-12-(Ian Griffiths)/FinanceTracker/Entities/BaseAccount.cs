using FinanceTracker.Interfaces;
using FinanceTracker.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace FinanceTracker.Entities
{
    public abstract class BaseAccount : IAccount
    {
        protected readonly List<Transaction> _transactions = [];
        protected readonly Money _initialBalance;

        public Guid Id { get; private set; }
        public string Name { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public Money Balance { get; protected set; }
        public TypeName Type { get; protected set; }

        public IEnumerable<Transaction> Transactions => _transactions.AsReadOnly();

        protected BaseAccount(string name, Money initialBalance, TypeName type)
        {
            Id = Guid.NewGuid();
            ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            Name = name;
            Balance = initialBalance;
            Type = type;
            CreateAt = DateTime.Now;
            _initialBalance = Balance;
        }

        protected void StoreTransaction(Transaction transaction) => _transactions.Add(transaction);
        protected void EnsureSameCurrency(Money amount)
        {
            if (this.Balance.Currency != amount.Currency)
            {
                throw new InvalidOperationException(
                    "Currency mismatch between account balance and transaction amount.");
            }
        }
        public abstract void Deposit(Money amount);
        public abstract void Withdraw(Money amount);
    }

    public enum TypeName
    {
        Cash,
        Bank,
        CreditCard,
        Investment
    }
}
