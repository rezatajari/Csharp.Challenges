using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyFoundation
{
    public class Account
    {
        private static int counter = 0;
        private readonly List<Transaction> _transactions = new();
        public Account(User user, Currency currency)
        {
            Number = new Random().Next(100, 199) + (++counter);
            User= user;
            Currency = currency;
            Balance = new Money(0, Currency);
        }
        public int Number { get; init; }
        public Currency Currency { get;init; }
        public User User { get;init; }
        public Money Balance { get; private set; }
        public IReadOnlyList<Transaction> Transactions => _transactions;
       
        public void Deposit(Money amount)
        {
            if (amount.Currency.Name!=Currency.Name)
                throw new ArgumentException("Currency mismatch.", nameof(amount));

            if (amount.Amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.", nameof(amount));

            Balance += amount;
            Transaction tx = new Transaction(amount, TransactionType.Deposit);
            _transactions.Add(tx);
        }

        public void Withdraw(Money amount)
        {
            if (amount.Currency.Name!=Currency.Name)
                throw new ArgumentException("Currency mismatch.", nameof(amount));

            if (amount.Amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.", nameof(amount));

            if (Balance.Amount < amount.Amount)
                throw new InvalidOperationException("Insufficient funds for withdrawal.");

            Balance -= amount;
            Transaction tx= new Transaction(amount, TransactionType.Withdrawal);
            _transactions.Add(tx);
        }

        public Money GetVerifiedBalance()
        {
            decimal total = 0;
            foreach(var tx in _transactions)
            {
                if (tx.Type == TransactionType.Deposit)
                    total += tx.Amount.Amount;
                else
                    total -= tx.Amount.Amount;
            }
            
            return new Money(total, Currency);
        }
    }
}
