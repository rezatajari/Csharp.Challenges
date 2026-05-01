using Application.Dtos.Requests;
using Application.Shared;
using UI.Models;

namespace UI.Services.Interfacies
{
    public interface IAuthService
    {
        Task<Result<bool>> Register(RegisterUserForm request);
        Task<Result<string>> Logn(LoginUserRequest request);
    }
}
