using FinanceTracker.Interfaces;
using FinanceTracker.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace FinanceTracker.Entities
{
    public abstract class BaseAccount : BaseEntity,IAccount
    {
        protected readonly Money _initialBalance;

        // For database (ef core) mapping
        private ICollection<Transaction> _transactions = new List<Transaction>();
        public string Name { get; protected set; }
        public Money Balance { get; protected set; }
        public TypeName Type { get; protected set; }

        // For expose
        public IEnumerable<Transaction> Transactions => _transactions;

        protected BaseAccount(string name, Money initialBalance, TypeName type)
        {
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
        public abstract Transaction Deposit(Money amount, DateTime createAt);
        public abstract Transaction Withdraw(Money amount, DateTime createAt);
    }

    public enum TypeName
    {
        Cash,
        Bank,
        CreditCard,
        Investment
    }
}
