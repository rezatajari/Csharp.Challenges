using Application.Dtos.Requests;
using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Application.Shared;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class AuthService(IAuthRepository authRepo, ILogger<AuthService> logger, IJwtProvider jwtProvider) : IAuthService
    {
        public async Task<Result<string>> Logn(LoginUserRequest request,CancellationToken ct)
        {
            var user=await authRepo.GetByIdAsync(request.id)
        }

        public async Task<Result<bool>> Register(RegisterUserRequest request,CancellationToken ct)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashed = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);

           var user= User.Create(request.Username, request.Email, hashed);

            await authRepo.AddAsync(user,ct);
            await authRepo.SaveChangesAsync(ct);

            return Result<bool>.Success(true);
        }
    }
}
