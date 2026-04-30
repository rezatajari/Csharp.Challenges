using Application.Dtos.Reponses;
using Application.Dtos.Requests;
using Application.Shared;
using Domain.ValueObjects;
using System.Net.Http.Json;
using UI.Services.Interfacies;

namespace UI.Services
{
    public class FinanceService(HttpClient client):BaseService,IFinanceService
    {

        public async Task<Result<bool>> CreateAccount(CreateAccountRequest request)
        {
            var response = await client.PostAsJsonAsync("api/finance/create-account", request);
            var f = await response.Content.ReadFromJsonAsync<Result<bool>>();
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Result<bool>>()
                    ?? Result<bool>.Failure("Unknow error");
                   
            string error = await GetErrorResponse(response);
            return Result<bool>.Failure(error);
        }

        public async Task<Result<List<AccountResponse>>> GetAllAccouintsAsync()
        {
            var response = await client.GetAsync("api/finance/accounts");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Result<List<AccountResponse>>>()
                       ?? Result<List<AccountResponse>>.Success([]);

            string error= await GetErrorResponse(response);
            return Result<List<AccountResponse>>.Failure(error);
        }

        public async Task<Result<AccountResponse>> GetAccountByIdAsync(int Id)
        {
            var response = await client.GetFromJsonAsync<ApiResult<AccountResponse>>($"api/finance/account/{Id}");
            return response ?? ApiResult<AccountResponse>.Failure("Empty response from server");
        }

        public async Task<Result<List<TransactionResponse>>> GetTransactionsByAccountIdAsync(int Id)
        {
            var response = await client.GetAsync($"api/finance/transaction/{Id}");
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return ApiResult<List<TransactionResponse>>.Failure($"Server said 400: {errorContent}");
            }
            var result = await response.Content.ReadFromJsonAsync<ApiResult<List<TransactionResponse>>>();
            return result ?? ApiResult<List<TransactionResponse>>.Failure("Empty response from server");
        }

        public async Task<Result<bool>> AddTransaction(InputTxRequest request)
        {
            var category = Category.Create(addTxModel.CategoryName, addTxModel.CategoryDescription);
            var amount = Money.Create(addTxModel.Amount, addTxModel.Currency);
            var inputTxDto = new InputTxRequest(addTxModel.AccountId, addTxModel.TargetAccountId, amount, category, addTxModel.Type, addTxModel.TransactionDescription);

            var response = await client.PostAsJsonAsync("api/finance/transaction/add", inputTxDto);
            var content = await response.Content.ReadFromJsonAsync<ApiResult<bool>>();

            return content ?? ApiResult<bool>.Failure("Cannot save your transaction");
        }

    }
}
