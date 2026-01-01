using System;
using System.Collections.Generic;
using System.Text;

namespace BankVault
{
    internal class BankAccount
    {
        private decimal _money = 0;
        public BankAccount(decimal amount)
        {
            AddMoney(amount);
        }
        public void AddMoney(decimal amount)
        {
            if (amount >= 0)
                _money += amount;
        }
        public void RemoveMoney(decimal amount)
        {
            if (amount > 0 && _money >= amount)
                _money -= amount;
        }
    }
}
