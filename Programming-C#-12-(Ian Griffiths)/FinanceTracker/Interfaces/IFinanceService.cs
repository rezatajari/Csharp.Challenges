using FinanceTracker.Entities;
using FinanceTracker.Shared;

namespace FinanceTracker.Interfaces
{
    internal interface IFinanceService
    {
        Task<Result<bool>> OpenAccount(BaseAccount newAccount);
        Task<Result<bool>> RecordTransaction(int accountId,Transaction transaction);
    }
}
