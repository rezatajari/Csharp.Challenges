using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyFoundation
{
    public class Bank
    {
        private readonly List<Account> _accounts = new();
        public int OpenAccount(User user, Currency currency)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrEmpty(currency.Name))
                throw new ArgumentException("Invalid Currency provided.", nameof(currency));

            Account account = new Account(user, currency);
            _accounts.Add(account);

            return account.Number;
        }

        public Account GetAccount(int accountNumber)
        {
            Account? account= _accounts.Where(a=>a.Number == accountNumber).FirstOrDefault();
            if (account == null)
                throw new ArgumentException("Account not found.", nameof(accountNumber));
            return account;
        }

        public void Transfer (int fromAccountNumber,int toAccountNumber,Money money)
        {
            Account fromAccount=GetAccount(fromAccountNumber);
            Account toAccount=GetAccount(toAccountNumber);

            fromAccount.Withdraw(money);
            toAccount.Deposit(money);
        }
    }
}
