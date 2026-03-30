using FinanceTracker.Dtos;
using FinanceTracker.Exceptions;
using FinanceTracker.Interfaces;
using FinanceTracker.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace FinanceTracker.Entities
{
    public class Account : BaseAccount
    {
        private Account(string name, Money initialBalance, TypeName type) : base(name, initialBalance, type)
        {
            if (initialBalance.Amount < 0)
            {
                throw new ArgumentException("Balance cannot be negative.", nameof(initialBalance));
            }
        }

        public static Account Create(string name, Money balance, TypeName type)
        {
            return new Account(name, balance, type);
        }

        public override void Deposit(Money amount)
        {
            Deposit(amount, Category.Create("Default", null, TransactionType.Income),
                    null, DateTime.Now);
        }

        public override void Withdraw(Money amount)
        {
            Withdraw(amount, Category.Create("Default", null, TransactionType.Income),
                null, DateTime.Now);
        }

        public Transaction Withdraw(Money amount, Category category, string? description, DateTime createAt)
        {
            EnsureSameCurrency(amount);

            if (Balance < amount)
            {
                throw new InsufficientFundsException("Insufficient balance for this transaction.");
            }

            var transaction = Transaction.CreateForAccount(amount, TransactionType.Expense,
                category, this, description, createAt);

            this.Balance -= amount;
            StoreTransaction(transaction);

            return transaction;
        }

        public Transaction Deposit(Money amount, Category category,
            string? description, DateTime createAt)
        {
            EnsureSameCurrency(amount);

            var transaction = Transaction.CreateForAccount(amount, TransactionType.Income,
                category, this, description, createAt);

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

        public TransferResult TransferTo(Account destination, Money amount, DateTime transferDate,
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
        => _transactions.Where(tx => tx.Category == category).ToList();

        public decimal GetTotalSpendingByCategory(Category category)
        => _transactions
                .Where(tx => tx.Category == category && tx.Type == TransactionType.Expense)
                .Sum(a => a.Amount.Amount);

        public List<CategorySummary> GetSpendingSummoryByCategory()
         => _transactions
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
                if (index < 0 || index >= _transactions.Count)
                    throw new IndexOutOfRangeException("Transaction index out of bounds.");

                return _transactions[index];
            }
        }

        public Transaction? this[Guid Id]
        {
            get
            {
                foreach (var tx in _transactions)
                {
                    if (tx.Id == Id) return tx;
                }
                return null;
            }
        }

       
    }
}
