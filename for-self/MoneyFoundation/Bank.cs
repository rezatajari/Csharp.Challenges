using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyFoundation
{
    public class Bank
    {
        private readonly List<Account> _accounts = new();
        public void OpenAccount(User user, Currency currency)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrEmpty(currency.Name))
                throw new ArgumentException("Invalid Currency provided.", nameof(currency));

            _accounts.Add(new Account(user, currency));
        }
    }
}
