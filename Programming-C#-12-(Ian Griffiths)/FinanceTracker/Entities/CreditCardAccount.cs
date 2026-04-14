using FinanceTracker.Exceptions;
using FinanceTracker.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public class CreditCardAccount : BaseAccount
    {
        protected CreditCardAccount() : base() { }
        private CreditCardAccount(string name, Money initialBalance, Money limit)
            : base(name, initialBalance, TypeName.CreditCard)
        {
            CreditLimit = limit;
        }
        public Money CreditLimit { get; private set; }

        public static CreditCardAccount Create(string name, Money initialBalance, Money limit)
        {
            if (limit.Amount < 0) throw new ArgumentException("Limit must be positive.");
            return new CreditCardAccount(name, initialBalance, limit);
        }

        public override Transaction Deposit(Money amount, DateTime createAt)
        {
            EnsureSameCurrency(amount);

            this.Balance += amount;

            var tx = Transaction.CreateForAccount(amount, TransactionType.Income,
                Category.Create("Charge", null, TransactionType.Income), this, "Credit Payment", createAt);

            StoreTransaction(tx);

            return tx;
        }

        public override Transaction Withdraw(Money amount, DateTime createAt)
        {
            EnsureSameCurrency(amount);

            if (this.Balance.Amount - amount.Amount < -this.CreditLimit.Amount)
                throw new CreditLimitExceedException("Transaction denied: Credit limit exceeded!",
                    amount.Amount, this.CreditLimit.Amount);

            this.Balance -= amount;

            var tx = Transaction.CreateForAccount(amount, TransactionType.Expense,
                Category.Create("Charge", null, TransactionType.Expense), this, "Credit Purchase", createAt);

            StoreTransaction(tx);

            return tx;
        }

    }
}
