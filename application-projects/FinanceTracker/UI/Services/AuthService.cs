
using Application.Dtos.Requests;
using Application.Shared;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using UI.Services.Interfaces;

namespace UI.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(HttpClient client,IJSRuntime jsRuntime) : base(client, jsRuntime) { }

        public async Task<Result<bool>> Register(RegisterUserRequest formModel)
        {
            var response = await _client.PostAsJsonAsync("api/auth/register", formModel);
            if (response.IsSuccessStatusCode)
            {
                bool isRegister=await response.Content.ReadFromJsonAsync<bool>();
                return Result<bool>.Success(isRegister);
            }

            string error = await GetErrorResponse(response);
            return Result<bool>.Failure(error);
        }
        public async Task<Result<bool>> Logn(LoginUserRequest formModel)
        {
            var response = await _client.PostAsJsonAsync("api/auth/login", formModel);
            if (response.IsSuccessStatusCode)
            {
                string? token = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(token))
                    return Result<bool>.Failure("Null token");

                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", token);

                return Result<bool>.Success(true);
            }

            string error = await GetErrorResponse(response);
            return Result<bool>.Failure(error);
        }
    }
}
