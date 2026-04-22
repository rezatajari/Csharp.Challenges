using Application.Dtos;
using Domain.Shared;
using System.Net.Http.Json;
using UI.Pages;
using static System.Net.WebRequestMethods;

namespace UI.Services
{
    public class AccountService
    {
        private readonly HttpClient _client;
        public AccountService(HttpClient client)
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

        public async Task<ApiResult<List<TransactionDto>>> GetTransactionsByAccountId(int Id) { 
        }
    }
}
