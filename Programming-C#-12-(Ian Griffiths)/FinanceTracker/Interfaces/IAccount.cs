using FinanceTracker.Entities;
using FinanceTracker.ValueObjects;

namespace FinanceTracker.Interfaces
{
    public interface IAccount: IEntity
    {
        string Name { get; }
        Money Balance { get; }
        TypeName Type { get; }
        void Deposit(Money amount, DateTime createAt);
        void Withdraw(Money amount, DateTime createAt);
    }
}

