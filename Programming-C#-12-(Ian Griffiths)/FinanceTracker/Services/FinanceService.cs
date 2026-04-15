using FinanceTracker.Data;
using FinanceTracker.Entities;
using FinanceTracker.Interfaces;
using FinanceTracker.Shared;
using FinanceTracker.ValueObjects;
using Microsoft.Identity.Client;
using System.Runtime.InteropServices.Marshalling;
using System.Security;

namespace FinanceTracker.Services
{
    public class FinanceService : IFinanceService
    {

        private readonly IBaseRepository<BaseAccount> _accountRepo;

        public FinanceService(IBaseRepository<BaseAccount> accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<Result<bool>> OpenAccount(BaseAccount newAccount)
        {
            await _accountRepo.AddAsync(newAccount);
            int rowsAffected = await _accountRepo.SaveChangesAsync();

            return rowsAffected > 0
                ? Result<bool>.Success(true)
                : Result<bool>.Failure("Failed to open account.");
        }

        public Task<Result<bool>> RecordTransaction(int accountId, Transaction transaction)
        {
            throw new NotImplementedException();
        }

        //public Result<bool> ExecutePurchase(Guid accountId, Money amount, string categoryName)
        //{
        //    return ExecuteSafe<bool>(() =>
        //    {
        //        var account = _accountRepo.GetById(accountId);

        //        if (account == null)
        //            throw new KeyNotFoundException($"Account with ID {accountId} not found.");

        //        account.Withdraw(amount, DateTime.Now);

        //        var category = Category.Create(categoryName, null, TransactionType.Expense);

        //        var purchaseTx = Transaction.CreateForAccount(amount, TransactionType.Expense,
        //            category, account, "Purchase", DateTime.Now);

        //        _transactionRepo.Add(purchaseTx);

        //        return true;
        //    });
        //}

        //public Result<bool> ExecuteTransfer(Guid fromAccountId, Guid toAccountId, Money amount)
        //{
        //    return ExecuteSafe<bool>(() =>
        //     {
        //         var fromAccount = _accountRepo.GetById(fromAccountId);
        //         var toAccount = _accountRepo.GetById(toAccountId);

        //         if (fromAccount == null || toAccount == null)
        //             throw new KeyNotFoundException($"One or both accounts were not found.");

        //         fromAccount.Withdraw(amount, DateTime.Now);
        //         toAccount.Deposit(amount, DateTime.Now);

        //         var transferCategory = Category.Create("Transfer", null, TransactionType.Transfer);

        //         var outTx = Transaction.CreateForAccount(amount, TransactionType.Expense,
        //             transferCategory, fromAccount, $"Transfer from {toAccount.Name}", DateTime.Now);

        //         var inTx = Transaction.CreateForAccount(amount, TransactionType.Income,
        //             transferCategory, toAccount, $"Transfer to {fromAccount.Name}", DateTime.Now);

        //         _transactionRepo.Add(outTx);
        //         _transactionRepo.Add(inTx);

        //         return true;
        //     });
        //}

        //public Result<Money> GetTotalNetWorth(Currency targetCurrency)
        //{
        //    return ExecuteSafe<Money>(() =>
        //    {
        //        var allAccount = _accountRepo.GetAll();
        //        decimal total = 0;

        //        foreach (var acc in allAccount)
        //        {
        //            if (acc.Balance.Currency != targetCurrency) continue;

        //            if (acc.Type == TypeName.CreditCard)
        //            {
        //                total -= acc.Balance.Amount;
        //            }
        //            else
        //            {
        //                total += acc.Balance.Amount;
        //            }
        //        }

        //        return Money.Create(total, targetCurrency);
        //    });
        //}

        //public Result<List<Transaction>> GetAllTransactions()
        //    => ExecuteSafe<List<Transaction>>(_transactionRepo.GetAll);
    }
}
