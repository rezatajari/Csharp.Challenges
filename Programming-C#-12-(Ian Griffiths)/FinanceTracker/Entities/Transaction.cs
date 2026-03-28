using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public class Transaction
    {
        private Transaction(decimal amount, Category category,
            Account account, string? description)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            }
            this.Amount = amount;

            if (category==null || account==null)
            {
                throw new ArgumentNullException("Category and Account cannot be null.");
            }
            this.Category = category;
            this.Account = account;

            this.Description = description;
            this.CreateAt = DateTime.Now;
        }
        public decimal Amount { get; private set; }
        public DateTime CreateAt { get; private set; }
        public Category Category { get; private set; }
        public Account Account { get; private set; }
        public string? Description { get; private set; }

        public static Transaction CreateTransaction(decimal amount, Category category,
            Account account, string? description)
        {
            return new Transaction(amount, category, account, description);
        }

    }
}
