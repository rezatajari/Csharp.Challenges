using Application.Dtos.Reponses;
using Application.Dtos.Requests;
using Application.Shared;
using Domain.ValueObjects;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using UI.Models;
using UI.Services.Interfacies;

namespace UI.Services
{
    public class FinanceService: BaseService,IFinanceService
    {
        public FinanceService(HttpClient client,IJSRuntime jsRuntime) :base(client,jsRuntime) {}
        public async Task<Result<bool>> CreateAccount(CreateAccountRequest request)
        {
            var response = await _client.PostAsJsonAsync("api/finance/create-account", request);
            if (response.IsSuccessStatusCode)
            {
                bool isCreated = await response.Content.ReadFromJsonAsync<bool>();
                return Result<bool>.Success(isCreated);
            };
                   
            string error = await GetErrorResponse(response);
            return Result<bool>.Failure(error);
        }

        public async Task<Result<List<AccountResponse>>> GetAllAccouintsAsync()
        {
            var response = await _client.GetAsync("api/finance/accounts");

            if (response.IsSuccessStatusCode)
            {
                List<AccountResponse>? accounts=await response.Content.ReadFromJsonAsync<List<AccountResponse>>();
                return Result<List<AccountResponse>>.Success(accounts ?? []);
            }

            string error= await GetErrorResponse(response);
            return Result<List<AccountResponse>>.Failure(error);
        }

        public async Task<Result<AccountResponse>> GetAccountByIdAsync(int Id)
        {
            var response = await _client.GetAsync($"api/finance/account/{Id}");
            if (response.IsSuccessStatusCode)
            {
                AccountResponse? account = await response.Content.ReadFromJsonAsync<AccountResponse>();
                return account != null
                    ? Result<AccountResponse>.Success(account)
                    : Result<AccountResponse>.Failure("Response from server is empty.");
            }
            
            string error=await GetErrorResponse(response);
            return Result<AccountResponse>.Failure(error);
        }

        public async Task<Result<List<TransactionResponse>>> GetTransactionsByAccountIdAsync(int Id)
        {
            var response = await _client.GetAsync($"api/finance/transaction/{Id}");
            if (response.IsSuccessStatusCode)
            {
                List<TransactionResponse>? transactions = await response.Content.ReadFromJsonAsync<List<TransactionResponse>>();
                return Result<List<TransactionResponse>>.Success(transactions ?? []);
            }
            string error=await GetErrorResponse(response);
            return Result<List<TransactionResponse>>.Failure(error);
        }

        public async Task<Result<bool>> AddTransaction(AddTransactionForm request)
        {
            var category = Category.Create(request.CategoryName, request.CategoryDescription);
            var amount = Money.Create(request.Amount, request.Currency);
            var inputTxDto = new AddTransaction(request.AccountId, request.TargetAccountId, amount, category,
                request.Type, request.TransactionDescription);

            var response = await _client.PostAsJsonAsync("api/finance/transaction/add", inputTxDto);
            var content = await response.Content.ReadFromJsonAsync<Result<bool>>();

            return content ?? Result<bool>.Failure("Cannot save your transaction");
        }

    }
}
