using Application.Dtos;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Interfaces
{
    public interface IFinanceService
    {
        Task<Result<bool>> OpenAccount(CreateAccountDto createAccDto);
        Task<Result<bool>> Income(InputTxDto IncomeTxDto);
        Task<Result<bool>> Expense(InputTxDto ExpenseTxDto);
        Task<Result<bool>> TransferFunds(int fromId, int toId, Money amount);
        Task<Result<List<AccountDto>>?> GetAccounts();
        Task<Result<AccountDto>> GetAccount(int Id);
        Task<Result<List<TransactionDto>>> GetTransactionById(int Id);
    }
}
