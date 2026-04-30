
using Application.Dtos.Requests;
using Application.Shared;
using UI.Services.Interfacies;

namespace UI.Services
{
    public class AuthService :BaseService, IAuthService
    {
        public AuthService(HttpClient client):base(client) { }

        public Task<Result<string>> Logn(LoginUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> Register(RegisterUserRequest request)
        {

        }
    }
}
