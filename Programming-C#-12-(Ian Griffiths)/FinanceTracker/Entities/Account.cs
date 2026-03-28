using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public class Account
    {
        private Account(string name,decimal balance, TypeName type,Currency currency)
        {
            this.Id=Guid.NewGuid();
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

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Money Balance { get;private set; }
        public List<Transaction> Transactions { get; private set; } = [];
        public TypeName Type { get;private set; }

        public static Account Create(string name,decimal balance, TypeName type,Currency currency)
        {
            return new Account(name,balance, type,currency);
        }

        public Transaction AddExpense(Money amount,Category category,string? description,DateTime createAt)
        {
            if (Money < amount)
            {
                throw new InvalidOperationException("Insufficient balance for this transaction.");
            }

            var transaction=Transaction.Create(amount,TransactionType.Expense,
                category,this,description, createAt);

            CreateAndStore(transaction);
            this.Balance -= amount;

            return transaction;
        }

        public Transaction AddIncome(decimal amount,Category category,
            string? description,DateTime createAt)
        {
            var transaction=Transaction.Create(amount,TransactionType.Income,
                category,this,description,createAt);

            CreateAndStore(transaction);
            this.Balance += amount;

            return transaction;
        }

        private void CreateAndStore(Transaction transaction) => this.Transactions.Add(transaction);
    }

    public enum TypeName
    {
        Cash,
        Bank,
        CreditCard,
        Investment
    }

   
}
