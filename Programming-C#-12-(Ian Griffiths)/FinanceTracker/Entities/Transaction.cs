using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public class Transaction
    {
        private Transaction(decimal amount, Category category,
            Account account, string? description,DateTime createAt)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            }
            this.Amount = amount;

            ArgumentNullException.ThrowIfNull(category, nameof(category));
            this.Category= category;

            ArgumentNullException.ThrowIfNull(account,nameof(account)); 
            this.Account= account;

            this.Description = description;
            this.CreateAt =createAt;
        }
        public decimal Amount { get; private set; }
        public DateTime CreateAt { get; private set; }
        public Category Category { get; private set; }
        public Account Account { get; private set; }
        public string? Description { get; private set; }

        public static Transaction Create(decimal amount, Category category,
            Account account, string? description,DateTime createAt)
        {
            return new Transaction(amount, category, account, description,createAt);
        }

    }
}
