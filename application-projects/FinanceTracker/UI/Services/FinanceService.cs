using Application.Dtos.Reponses;
using Application.Dtos.Requests;
using Application.Shared;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace UI.Services
{
    public class FinanceService:BaseService
    {
        private readonly HttpClient _client;
        public FinanceService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Result<bool>> CreateAccount(CreateAccountRequest dto)
        {
            var response = await _client.PostAsJsonAsync("api/finance/create-account", dto);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Result<bool>>();

            string error = await GetErrorResponse(response);
            return Result<bool>.Failure(error);

        }

        

        public async Task<List<AccountResponse>> GetAllAccounts()
        {
            var response = await _client.GetFromJsonAsync<ApiResult<List<AccountResponse>>>("api/finance/accounts");
            return response ??
        }


        public async Task<ApiResult<AccountResponse>> GetAccount(int Id)
        {
            var response = await _client.GetFromJsonAsync<ApiResult<AccountResponse>>($"api/finance/account/{Id}");
            return response ?? ApiResult<AccountResponse>.Failure("Empty response from server");
        }

        public async Task<ApiResult<List<TransactionResponse>>> GetTransactionsByAccountId(int Id)
        {
            var response = await _client.GetAsync($"api/finance/transaction/{Id}");
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return ApiResult<List<TransactionResponse>>.Failure($"Server said 400: {errorContent}");
            }
            var result = await response.Content.ReadFromJsonAsync<ApiResult<List<TransactionResponse>>>();
            return result ?? ApiResult<List<TransactionResponse>>.Failure("Empty response from server");
        }

        public async Task<ApiResult<bool>> AddTransaction(AddTransactionFrom addTxModel)
        {
            var category = Category.Create(addTxModel.CategoryName, addTxModel.CategoryDescription);
            var amount = Money.Create(addTxModel.Amount, addTxModel.Currency);
            var inputTxDto = new InputTxRequest(addTxModel.AccountId, addTxModel.TargetAccountId, amount, category, addTxModel.Type, addTxModel.TransactionDescription);

            var response = await _client.PostAsJsonAsync("api/finance/transaction/add", inputTxDto);
            var content = await response.Content.ReadFromJsonAsync<ApiResult<bool>>();

            return content ?? ApiResult<bool>.Failure("Cannot save your transaction");
        }
    }
}
