using FinanceTracker.Entities;
using FinanceTracker.ValueObjects;

namespace FinanceTracker.Interfaces
{
    public interface IAccount
    {
        string Name { get; }
        Money Balance { get; }
        TypeName Type { get; }
        Transaction Deposit(Money amount, DateTime createdAt);
        Transaction Withdraw(Money amount, DateTime createdAt);
    }
}

