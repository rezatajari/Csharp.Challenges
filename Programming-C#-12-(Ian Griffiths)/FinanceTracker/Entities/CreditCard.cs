using FinanceTracker.Exceptions;
using FinanceTracker.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public class CreditCard : BaseAccount
    {
        private CreditCard(string name, Money initialBalance, Money limit)
            : base(name, initialBalance, TypeName.CreditCard)
        {
            CreditLimit = limit;
        }
        public Money CreditLimit { get; private set; }

        public static CreditCard Create(string name, Money initialBalance, Money limit)
        {
            if (limit.Amount < 0) throw new ArgumentException("Limit must be positive.");
            return new CreditCard(name, initialBalance, limit);
        }

        public override void Deposit(Money amount)
        {
            EnsureSameCurrency(amount);

            this.Balance += amount;

            var tx = Transaction.CreateForAccount(amount, TransactionType.Income,
                Category.Create("Charge", null, TransactionType.Income), this, "Credit Payment", DateTime.Now);

            StoreTransaction(tx);
        }

        public override void Withdraw(Money amount)
        {
            EnsureSameCurrency(amount);

            if (this.Balance.Amount - amount.Amount < -this.CreditLimit.Amount)
                throw new CreditLimitExceedException("Transaction denied: Credit limit exceeded!",
                    amount.Amount, this.CreditLimit.Amount);

            this.Balance -= amount;

            var tx = Transaction.CreateForAccount(amount, TransactionType.Expense,
                Category.Create("Charge", null, TransactionType.Expense), this, "Credit Purchase", DateTime.Now);

            StoreTransaction(tx);
        }

    }
}
