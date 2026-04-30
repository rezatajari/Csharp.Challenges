using Application.Dtos.Requests;
using Application.Shared;

namespace UI.Services.Interfacies
{
    public interface IAuthService
    {
        Task<Result<bool>> Register(RegisterUserRequest request);
        Task<Result<string>> Logn(LoginUserRequest request);
    }
}
