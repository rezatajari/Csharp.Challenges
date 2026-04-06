using FinanceTracker.Entities;
using FinanceTracker.ValueObjects;

namespace FinanceTracker.Interfaces
{
    public interface IAccount: IEntity
    {
        string Name { get; }
        Money Balance { get; }
        TypeName Type { get; }
        Transaction Deposit(Money amount, DateTime createAt);
        Transaction Withdraw(Money amount, DateTime createAt);
    }
}

