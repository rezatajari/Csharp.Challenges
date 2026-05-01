using Application.Dtos.Requests;
using Application.Shared;

namespace UI.Services.Interfacies
{
    public interface IAuthService
    {
        Task<Result<bool>> Register(RegisterUserRequest registerModel);
        Task<Result<bool>> Logn(LoginUserRequest loginModel);
    }
}
