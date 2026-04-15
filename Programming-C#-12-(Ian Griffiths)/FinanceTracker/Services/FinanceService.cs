using FinanceTracker.Data;
using FinanceTracker.Dtos;
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
        private readonly IBaseRepository<Transaction> _transactionRepo;

        public FinanceService(IBaseRepository<BaseAccount> accountRepo,IBaseRepository<Transaction> transactionRepo)
        {
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<Result<bool>> OpenAccount(BaseAccount newAccount)
        {
            await _accountRepo.AddAsync(newAccount);
            int rowsAffected = await _accountRepo.SaveChangesAsync();

            return rowsAffected > 0
                ? Result<bool>.Success(true)
                : Result<bool>.Failure("Failed to open account.");
        }

        public async Task<Result<bool>> RecordIncome(InputRecordTxDto IncomeTx)
        {
            var account = await _accountRepo.GetByIdAsync(IncomeTx.accountId);
            if (account == null)
                return Result<bool>.Failure("Account not found.");

            DateTime now = DateTime.UtcNow;
            var createTx=Transaction.Create(IncomeTx.amount,TransactionType.Income,
                IncomeTx.category,account,IncomeTx.description, now);

            if (account is SavingsAccount savings)
            {
                savings.Deposit(IncomeTx.amount,IncomeTx.category, IncomeTx.description, now);
            }


             await _transactionRepo.AddAsync(createTx);
        }

        public async Task<Result<bool>> RecordExpense(InputRecordTxDto ExpenseTx)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> TransferFunds(int fromId, int toId, Money amount)
        {
            throw new NotImplementedException();
        }
   
    }
}
