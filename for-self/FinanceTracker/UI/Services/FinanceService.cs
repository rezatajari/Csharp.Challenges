using Application.Dtos;
using Domain.Shared;
using System.Net.Http.Json;

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
            var response = await _client.GetFromJsonAsync<ApiResult<List<TransactionDto>>>($"api/finance/transaction/{Id}")
            return response ?? ApiResult<List<TransactionDto>>.Failure("There is no any transactions");
        }
    }
}
