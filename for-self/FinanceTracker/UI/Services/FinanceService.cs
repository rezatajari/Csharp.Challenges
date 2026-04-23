using Application.Dtos;
using Domain.Shared;
using Domain.ValueObjects;
using System.Net.Http.Json;
using static UI.Components.TransactionFormModal;
using static UI.Pages.AccountDetails;

namespace UI.Services
{
    public class FinanceService
    {
        private readonly HttpClient _client;
        public FinanceService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResult<bool>> CreateAccount(CreateAccountDto dto)
        {
            var response = await _client.PostAsJsonAsync("api/finance/create-account", dto);

            return await response.Content.ReadFromJsonAsync<ApiResult<bool>>()
                ?? ApiResult<bool>.Failure("Error connect to server");
        }

        public async Task<ApiResult<List<AccountDto>>> GetAllAccounts()
        {
            var response = await _client.GetFromJsonAsync<ApiResult<List<AccountDto>>>("api/finance/accounts");
            return response ?? ApiResult<List<AccountDto>>.Failure("Empty response from server");
        }


        public async Task<ApiResult<AccountDto>> GetAccount(int Id)
        {
            var response = await _client.GetFromJsonAsync<ApiResult<AccountDto>>($"api/finance/account/{Id}");
            return response ?? ApiResult<AccountDto>.Failure("Empty response from server");
        }

        public async Task<ApiResult<List<TransactionDto>>> GetTransactionsByAccountId(int Id) 
        {
            var response = await _client.GetAsync($"api/finance/transaction/{Id}");
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return ApiResult<List<TransactionDto>>.Failure($"Server said 400: {errorContent}");
            }
            var result = await response.Content.ReadFromJsonAsync<ApiResult<List<TransactionDto>>>();
            return result ?? ApiResult<List<TransactionDto>>.Failure("Empty response from server");
        }

        public async Task<ApiResult<bool>> AddTransaction(AddTransactionFrom addTxModel)
        {
            var category = Category.Create(addTxModel.CategoryName, addTxModel.CategoryDescription);
            var amount=Money.Create(addTxModel.Amount, addTxModel.Currency);
            var inputTxDto = new InputTxDto(addTxModel.AccountId, addTxModel.TargetAccountId, amount, category, addTxModel.Type, addTxModel.TransactionDescription);

            var response = await _client.PostAsJsonAsync("api/finance/transaction/add", inputTxDto);
            var content = await response.Content.ReadFromJsonAsync<ApiResult<bool>>();

            return content ?? ApiResult<bool>.Failure("Cannot save your transaction");
        }
    }
}
