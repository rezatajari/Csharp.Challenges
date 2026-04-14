using FinanceTracker.Interfaces;
using FinanceTracker.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public class Bank
    {
        private readonly List<IAccount> _accounts = [];

        public IEnumerable<IAccount> Accounts => _accounts.AsReadOnly();

        public void AddAccount(IAccount account) => _accounts.Add(account);

        public List<Money> GetTotalNetWorths()
            => _accounts.GroupBy(acc => acc.Balance.Currency)
                .Select(group => Money.Create(
                    group.Sum(a => a.Balance.Amount),
                    group.Key))
                .ToList();

        public IAccount? GetAccountByName(string name)
             => _accounts.FirstOrDefault(acc => acc.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public List<CreditCardAccount> GetCreditCards()
            => _accounts.OfType<CreditCardAccount>().ToList();

        public List<IAccount> GetAccountInDebt()
            => _accounts.Where(acc=>acc.Balance.Amount<0).ToList(); 
    }
}
