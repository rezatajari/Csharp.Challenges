using FinanceTracker.Data;
using FinanceTracker.Entities;
using FinanceTracker.Interfaces;
using FinanceTracker.Shared;
using FinanceTracker.ValueObjects;
using System.Runtime.InteropServices.Marshalling;
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

        private Result<T> ExecuteSafe<T>(Func<T> businessLogic)
        {
            try
            {
                return Result<T>.Success(businessLogic());
            }
            catch (Exception ex)
            {
                return Result<T>.Failure(ex.Message);
            }
        }

        public Result<Guid> OpenAccount(IAccount newAccount)
        {
           return ExecuteSafe<Guid>(() =>
            {
                _accountRepo.Add(newAccount);
                var createAt = DateTime.Now;
                return newAccount.Id;
            });
        }

        public Result<bool> ExecutePurchase(Guid accountId, Money amount, string categoryName)
        {
            return ExecuteSafe<bool>(() =>
            {
                var account = _accountRepo.GetById(accountId);

                if (account == null)
                    throw new KeyNotFoundException($"Account with ID {accountId} not found.");

                account.Withdraw(amount, DateTime.Now);

                var category = Category.Create(categoryName, null, TransactionType.Expense);

                var purchaseTx = Transaction.CreateForAccount(amount, TransactionType.Expense,
                    category, account, "Purchase", DateTime.Now);

                _transactionRepo.Add(purchaseTx);

                return true;
            });
        }

        public Result<bool> ExecuteTransfer(Guid fromAccountId,Guid toAccountId,Money amount)
        {
           return ExecuteSafe<bool>(() =>
            {
                var fromAccount = _accountRepo.GetById(fromAccountId);
                var toAccount = _accountRepo.GetById(toAccountId);

                if (fromAccount == null || toAccount == null)
                    throw new KeyNotFoundException ($"One or both accounts were not found.");

                fromAccount.Withdraw(amount, DateTime.Now);
                toAccount.Deposit(amount, DateTime.Now);

                var transferCategory = Category.Create("Transfer", null, TransactionType.Transfer);

                var outTx = Transaction.CreateForAccount(amount, TransactionType.Expense,
                    transferCategory, fromAccount, $"Transfer from {toAccount.Name}", DateTime.Now);

                var inTx = Transaction.CreateForAccount(amount, TransactionType.Income,
                    transferCategory, toAccount, $"Transfer to {fromAccount.Name}", DateTime.Now);

                _transactionRepo.Add(outTx);
                _transactionRepo.Add(inTx);

                return true;
            });
        }

        public Result<Money> GetTotalNetWorth(Currency targetCurrency)
        {
            return ExecuteSafe<Money>(() =>
            {
                var allAccount = _accountRepo.GetAll();
                decimal total = 0;

                foreach (var acc in allAccount)
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
            });
        }

        public Result<List<Transaction>> GetAllTransactions()
            => ExecuteSafe<List<Transaction>>(_transactionRepo.GetAll);
    }
}
