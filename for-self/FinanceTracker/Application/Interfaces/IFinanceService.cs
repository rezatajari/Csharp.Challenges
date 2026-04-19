using Domain.Entities;
using Application.Dtos;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Interfaces
{
    public interface IFinanceService
    {
        Task<Result<bool>> OpenAccount(BaseAccount newAccount);
        Task<Result<bool>> RecordIncome(InputRecordTxDto IncomeTx);
        Task<Result<bool>> RecordExpense(InputRecordTxDto ExpenseTx);
        Task<Result<bool>> TransferFunds(int fromId, int toId, Money amount);
    }
}
