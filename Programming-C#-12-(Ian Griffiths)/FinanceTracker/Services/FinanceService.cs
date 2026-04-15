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

        public FinanceService(IBaseRepository<BaseAccount> accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<Result<bool>> OpenAccount(BaseAccount newAccount)
        {
            await _accountRepo.AddAsync(newAccount);

            return (await _accountRepo.SaveChangesAsync()>0)
                ? Result<bool>.Success(true)
                : Result<bool>.Failure("Failed to open account.");
        }

        public async Task<Result<bool>> RecordIncome(InputRecordTxDto IncomeTx)
        {
            var account = await _accountRepo.GetByIdAsync(IncomeTx.accountId);
            if (account == null)
                return Result<bool>.Failure("Account not found.");

            account.Deposit(IncomeTx.amount, IncomeTx.category,
                IncomeTx.description, DateTime.UtcNow);

            return (await _accountRepo.SaveChangesAsync() > 0)
                ? Result<bool>.Success(true)
                : Result<bool>.Failure("Failed to record income.");
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
