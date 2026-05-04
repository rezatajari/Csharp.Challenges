using Application.Dtos.Reponses;
using Application.Dtos.Requests;
using Application.Shared;
using Blazored.LocalStorage;
using Domain.ValueObjects;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using UI.Models;
using UI.Services.Interfaces;

namespace UI.Services
{
    public class FinanceService(HttpClient client, ILocalStorageService localStorage) 
        : BaseService(client, localStorage), IFinanceService
    {
        public async Task<Result<bool>> CreateAccountAsync(CreateAccountRequest request)
        {
            var response = await _client.PostAsJsonAsync("api/finance/create-account", request);
            return await ToResult<bool>(response);
        }

        public async Task<Result<List<AccountResponse>>> GetAllAccouintsAsync()
        {
            var response = await _client.GetAsync("api/finance/accounts");
            return await ToResult<List<AccountResponse>>(response);
        }

        public async Task<Result<AccountResponse>> GetAccountByIdAsync(int Id)
        {
            var response = await _client.GetAsync($"api/finance/account/{Id}");
            return await ToResult<AccountResponse>(response);
        }

        public async Task<Result<List<TransactionResponse>>> GetTransactionsByAccountIdAsync(int Id)
        {
            var response = await _client.GetAsync($"api/finance/transaction/{Id}");
            return await ToResult<List<TransactionResponse>>(response);
        }

        public async Task<Result<bool>> AddTransactionAsync(AddTransactionRequest request)
        {
            var response = await _client.PostAsJsonAsync("api/finance/transaction", request);
            return await  ToResult<bool>(response);
        }

        public async Task<Result<DashboardResponse>> GetDashboardAsync()
        {
            var response = await _client.GetAsync("api/finance/dashboard");
            return await ToResult<DashboardResponse>(response);
        }

        public async Task<Result<bool>> DeleteAccountAsync(int Id)
        {
            var response = await _client.DeleteAsync($"api/finance/delete/{Id}");
            return await ToResult<bool>(response);
        }
    }
}
