using Application.Dtos.Reponses;
using Application.Dtos.Requests;
using Application.Shared;

namespace UI.Services.Interfacies
{
    public interface IFinanceService
    {
        Task<Result<bool>> CreateAccount(CreateAccountRequest request);
        Task<Result<List<AccountResponse>>> GetAllAccouintsAsync();
        Task <Result<AccountResponse>> GetAccountByIdAsync(int Id);
        Task<Result<List<TransactionResponse>>> GetTransactionsByAccountIdAsync(int Id);
        Task<Result<bool>> AddTransaction(InputTxRequest request);
    }
}
