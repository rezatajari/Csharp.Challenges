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
            int rowsAffected = await _accountRepo.SaveChangesAsync();

            return rowsAffected > 0
                ? Result<bool>.Success(true)
                : Result<bool>.Failure("Failed to open account.");
        }

        public Task<Result<bool>> RecordTransaction(int accountId, Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> TransferFunds(int fromId, int toId, Money amount)
        {
            throw new NotImplementedException();
        }

        Task<Result<bool>> IFinanceService.RecordExpense(InputRecordTxDto ExpenseTx)
        {
            throw new NotImplementedException();
        }

        Task<Result<bool>> IFinanceService.RecordIncome(InputRecordTxDto IncomeTx)
        {
            throw new NotImplementedException();
        }

   
    }
}
