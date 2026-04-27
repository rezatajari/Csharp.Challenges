using Application.Dtos.Requests;
using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Application.Shared;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Services
{
    public class AuthService(IAuthRepository authRepo, ILogger<AuthService> logger, IJwtProvider jwtProvider) : IAuthService
    {
        public async Task<Result<string>> Logn(LoginUserRequest request,CancellationToken ct)
        {
            var user=await authRepo.GetByEmailAsync(request.Email,ct);
            if (user == null)
                return Result<string>.Failure("The user is not exist");

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
                return Result<string>.Failure("Invalid credentials");

            string token=jwtProvider.Generate(user);
            return Result<string>.Success(token);
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
