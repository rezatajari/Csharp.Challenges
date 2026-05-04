using Application.Dtos.Reponses;
using Application.Dtos.Requests;
using Application.Shared;
using UI.Models;

namespace UI.Services.Interfaces
{
    public interface IFinanceService
    {
        Task<Result<DashboardResponse>> GetDashboardAsync();
        Task<Result<bool>> CreateAccountAsync(CreateAccountRequest request);
        Task<Result<List<AccountResponse>>> GetAllAccouintsAsync();
        Task <Result<AccountResponse>> GetAccountByIdAsync(int Id);
        Task<Result<List<TransactionResponse>>> GetTransactionsByAccountIdAsync(int Id);
        Task<Result<bool>> AddTransactionAsync(AddTransactionRequest request);
        Task<Result<bool>> DeleteAccountAsync(int Id);
    }
}
