using Application.Dtos;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Interfaces
{
    public interface IFinanceService
    {
        Task<Result<bool>> OpenAccount(CreateAccountDto createAccDto, CancellationToken ct);
        Task<Result<bool>> AddTransaction(InputTxDto txDto, CancellationToken ct);
        Task<Result<List<AccountDto>>?> GetAccounts(CancellationToken ct);
        Task<Result<AccountDto>> GetAccount(int Id, CancellationToken ct);
        Task<Result<List<TransactionDto>>> GetTransactionById(int Id, CancellationToken ct);
    }
}
