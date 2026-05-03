using Application.Dtos.Reponses;
using Application.Dtos.Requests;
using Application.Shared;
using Domain.ValueObjects;

namespace Application.Interfaces
{
    public interface IFinanceService
    {
        Task<Result<bool>> OpenAccount(CreateAccountRequest createAccDto,int userId, CancellationToken ct);
        Task<Result<bool>> AddTransaction(AddTransaction txDto, CancellationToken ct);
        Task<Result<List<AccountResponse>>?> GetAccounts(CancellationToken ct);
        Task<Result<AccountResponse>> GetAccount(int Id, CancellationToken ct);
        Task<Result<List<TransactionResponse>>> GetAccountTransactions(int Id, CancellationToken ct);
        Task<Result<DashboardResponse>> GetDashboard(int userId, CancellationToken ct);
    }
}
