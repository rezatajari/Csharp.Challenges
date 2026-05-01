
using Application.Dtos.Requests;
using Application.Shared;
using System.Net.Http.Json;
using UI.Models;
using UI.Services.Interfacies;

namespace UI.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(HttpClient client) : base(client) { }

        public async Task<Result<bool>> Register(RegisterUserForm formModel)
        {
            var request=new RegisterUserRequest(formModel.Username, formModel.Email,formModel.Password,formModel.ConfirmPassword);
            var response = await _client.PostAsJsonAsync("api/auth/register", request);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Result<bool>>()
                    ?? Result<bool>.Failure("Unknow error");

            string error = await GetErrorResponse(response);
            return Result<bool>.Failure(error);
        }
        public async Task<Result<bool>> Logn(LoginUserForm formModel)
        {

            var request = new LoginUserRequest(formModel.Email, formModel.Password);
            var response = await _client.PostAsJsonAsync("api/auth/login", request);
            if (response.IsSuccessStatusCode)
            {

            }

        }

    }
}
