using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public class Account
    {
        private Account(string name,decimal balance, TypeName type,Currency currency)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(name,nameof(name));
            this.Name = name;

            if (balance < 0)
            {
                throw new ArgumentException("Balance cannot be negative.", nameof(balance));
            }
            this.Balance = balance;

            this.Type = type;
            this.Currency = currency;
        }

        public string Name { get; private set; }
        public decimal Balance { get;private set; }
        public List<Transaction> Transactions { get; private set; } = [];
        public TypeName Type { get;private set; }
        public Currency Currency{ get; private set; }

        public static Account Create(string name,decimal balance, TypeName type,Currency currency)
        {
            return new Account(name,balance, type,currency);
        }

        public void AddTransaction(Transaction transaction)
        {
            ArgumentNullException.ThrowIfNull(transaction, nameof(transaction));
            this.Transactions.Add(transaction);

            if (transaction.Type == TransactionType.Income)
            {
                this.Balance += transaction.Amount;
            }else if (transaction.Type == TransactionType.Expense)
            {
                this.Balance -= transaction.Amount;
            }
        }
    }

    public enum TypeName
    {
        Cash,
        Bank,
        CreditCard,
        Investment
    }

    public enum Currency
    {
        USD,
        EUR,
        GBP
    }
}
