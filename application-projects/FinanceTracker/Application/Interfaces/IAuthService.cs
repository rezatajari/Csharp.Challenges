using Application.Dtos.Requests;
using Application.Shared;



namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<Result<bool>> Register(RegisterUserRequest request,CancellationToken ct);
        Task<Result<string>> Logn(LoginUserRequest request, CancellationToken ct);
    }
}
