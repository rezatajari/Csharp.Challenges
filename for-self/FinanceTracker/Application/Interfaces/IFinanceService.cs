using Domain.Entities;
using FinanceTracker.ValueObjects;
using Application.Dtos;

namespace Application.Interfaces
{
    internal interface IFinanceService
    {
        Task<Result<bool>> OpenAccount(BaseAccount newAccount);
        Task<Result<bool>> RecordIncome(InputRecordTxDto IncomeTx);
        Task<Result<bool>> RecordExpense(InputRecordTxDto ExpenseTx);
        Task<Result<bool>> TransferFunds(int fromId, int toId, Money amount);
    }
}
