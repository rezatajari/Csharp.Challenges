using FinanceTracker.Data;
using FinanceTracker.Entities;
using FinanceTracker.Interfaces;
using FinanceTracker.ValueObjects;
using System.Security;

namespace FinanceTracker.Services
{
    public class FinanceService
    {
        private readonly Repository<IAccount> _accountRepo;
        private readonly Repository<Transaction> _transactionRepo;

        public FinanceService(
            Repository<IAccount> accountRepo,
            Repository<Transaction> transactionRepo
            )
        {
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
        }

        public Guid OpenAccount(IAccount newAccount, Money initialDeposit)
        {
            _accountRepo.Add(newAccount);

            if (initialDeposit.Amount > 0)
            {
                newAccount.Deposit(initialDeposit);

                var depositTx = Transaction.CreateForAccount(
                    initialDeposit,
                    TransactionType.Income,
                    Category.Create("Initial Deposit", null, TransactionType.Income),
                    newAccount,
                    "Opening Balance",
                    DateTime.Now
                    );

                _transactionRepo.Add(depositTx);
            }

            return newAccount.Id;
        }

        public void ExecutePurchase(Guid accountId, Money amount, string categoryName)
        {
            var account = _accountRepo.GetById(accountId);

            if (account == null)
                throw new KeyNotFoundException($"Account with ID {accountId} not found.");

            account.Withdraw(amount);

            var category = Category.Create(categoryName, null, TransactionType.Expense);

            var purchaseTx = Transaction.CreateForAccount(amount, TransactionType.Expense, 
                category, account, "Purchase", DateTime.Now);
            
            _transactionRepo.Add(purchaseTx);
        }

        public void ExecuteTransfer(Guid fromAccountId,Guid toAccountId,Money amount)
        {
            var fromAccount=_accountRepo.GetById(fromAccountId);
            var toAccount = _accountRepo.GetById(toAccountId);

            if (fromAccount == null || toAccount == null)
                throw new KeyNotFoundException($"One or both accounts were not found.");

            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);

            var transferCategory=Category.Create("Transfer",null,TransactionType.Transfer);

            var outTx = Transaction.CreateForAccount(amount, TransactionType.Expense,
                transferCategory, fromAccount, $"Transfer to {toAccount.Name}", DateTime.Now);

            var inTx = Transaction.CreateForAccount(amount, TransactionType.Income,
                transferCategory, toAccount, $"Transfer from {fromAccount}", DateTime.Now);

            _transactionRepo.Add(outTx);
            _transactionRepo.Add(inTx);
        }

        public Money GetTotalNetWorth(Currency targetCurrency)
        {
            var allAccount = _accountRepo.GetAll();
            decimal total=0;

            foreach(var acc in allAccount)
            {
                if (acc.Balance.Currency != targetCurrency) continue;

                if (acc.Type == TypeName.CreditCard)
                {
                    total -= acc.Balance.Amount; 
                }
                else
                {
                    total += acc.Balance.Amount; 
                }
            }

            return Money.Create(total, targetCurrency);
        }

        public List<Transaction> GetAllTransactions()
            => _transactionRepo.GetAll();
    }
}
