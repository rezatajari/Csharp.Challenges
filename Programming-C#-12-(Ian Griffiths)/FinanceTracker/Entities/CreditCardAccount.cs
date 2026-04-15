using FinanceTracker.Exceptions;
using FinanceTracker.ValueObjects;

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

        public override Transaction Deposit(Money amount, Category category,
            string? description, DateTime createdAt)
        {
            EnsureSameCurrency(amount);

            this.Balance += amount;

            var tx = Transaction.Create(amount, TransactionType.Income,
                Category.Create("Charge", null, TransactionType.Income), this, "Credit Payment", createdAt);

            StoreTransaction(tx);

            return tx;
        }

        public override Transaction Withdraw(Money amount, Category category,
            string? description, DateTime createdAt)
        {
            EnsureSameCurrency(amount);

            if (this.Balance.Amount - amount.Amount < -this.CreditLimit.Amount)
                throw new CreditLimitExceedException("Transaction denied: Credit limit exceeded!",
                    amount.Amount, this.CreditLimit.Amount);

            this.Balance -= amount;

            var tx = Transaction.Create(amount, TransactionType.Expense,
                Category.Create("Charge", null, TransactionType.Expense), this, "Credit Purchase", createdAt);

            StoreTransaction(tx);

            return tx;
        }

    }
}
