using Application.Dtos;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Interfaces
{
    public interface IFinanceService
    {
        Task<Result<bool>> OpenAccount(CreateAccountDto createAccDto);
        Task<Result<bool>> RecordIncome(InputRecordTxDto IncomeTxDto);
        Task<Result<bool>> RecordExpense(InputRecordTxDto ExpenseTxDto);
        Task<Result<bool>> TransferFunds(int fromId, int toId, Money amount);
        Task<Result<List<AccountDto>>?> GetAccounts();
        Task<Result<AccountDto>> GetAccount(int Id);
    }
}
