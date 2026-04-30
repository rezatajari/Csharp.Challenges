using Application.Dtos.Reponses;
using Application.Dtos.Requests;
using Application.Shared;
using Domain.ValueObjects;
using System.Net.Http.Json;
using UI.Models;
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
            var response = await client.GetAsync($"api/finance/account/{Id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Result<AccountResponse>>()
                    ?? Result<AccountResponse>.Failure("Unkow error");
            
            string error=await GetErrorResponse(response);
            return Result<AccountResponse>.Failure(error);
        }

        public async Task<Result<List<TransactionResponse>>> GetTransactionsByAccountIdAsync(int Id)
        {
            var response = await client.GetAsync($"api/finance/transaction/{Id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Result<List<TransactionResponse>>>()
                    ?? Result<List<TransactionResponse>>.Success([]);

            string error=await GetErrorResponse(response);
            return Result<List<TransactionResponse>>.Failure(error);
        }

        public async Task<Result<bool>> AddTransaction(AddTransactionFrom request)
        {
            var category = Category.Create(request.CategoryName,request.CategoryDescription);
            var amount = Money.Create(request.Amount, request.Currency);
            var inputTxDto = new InputTxRequest(request.AccountId, request.TargetAccountId, amount, category, request.Type, request.TransactionDescription);

            var response = await client.PostAsJsonAsync("api/finance/transaction/add", inputTxDto);
            var content = await response.Content.ReadFromJsonAsync<Result<bool>>();

            return content ?? Result<bool>.Failure("Cannot save your transaction");
        }

    }
}
