using FinanceTracker.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Interfaces
{
    public interface IAccount: IEntity
    {
        string Name { get; }
        Money Balance { get; }
        void Deposit(Money amount);
        void Withdraw(Money amount);
    }
}

