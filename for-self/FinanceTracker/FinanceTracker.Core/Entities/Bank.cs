using FinanceTracker.Interfaces;
using FinanceTracker.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Entities
{
    public class Bank
    {
        private readonly List<BaseAccount> _accounts = [];

        public IEnumerable<BaseAccount> Accounts => _accounts.AsReadOnly();

        public void AddAccount(BaseAccount account) => _accounts.Add(account);

        public List<Money> GetTotalNetWorths()
            => _accounts.GroupBy(acc => acc.Balance.Currency)
                .Select(group => Money.Create(
                    group.Sum(a => a.Balance.Amount),
                    group.Key))
                .ToList();

        public BaseAccount? GetAccountByName(string name)
             => _accounts.FirstOrDefault(acc => acc.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public List<CreditCardAccount> GetCreditCards()
            => _accounts.OfType<CreditCardAccount>().ToList();

        public List<BaseAccount> GetAccountInDebt()
            => _accounts.Where(acc=>acc.Balance.Amount<0).ToList(); 
    }
}
