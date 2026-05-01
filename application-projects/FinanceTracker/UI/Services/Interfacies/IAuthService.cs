using Application.Dtos.Requests;
using Application.Shared;
using UI.Models;

namespace UI.Services.Interfacies
{
    public interface IAuthService
    {
        Task<Result<bool>> Register(RegisterUserForm formModel);
        Task<Result<bool>> Logn(LoginUserForm formModel);
    }
}
